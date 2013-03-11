using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Windows.Forms;

// TODO: This whole thing needs to be re-written to not require XNA
// It's not available everywhere and it has a bad delay due to pumping

namespace ClapperApp
{
    class Clapper 
    {
        enum ClapperState
        {
            WaitLow,    // waiting for state to go high
            WaitHigh,   // waiting for state to go low
            WaitLow2,   // waiting for second state to go high
            WaitHigh2,   // waiting for second state to go low
        }

        Timer t; // used for XNA Framework crap
        Microphone m;

        byte[] buffer;
        ClapperState state;

        Queue<short> window;
        readonly int windowSize = 20;
        Stopwatch eventWatch;

        public delegate void RawClapperEventHandler(object sender, RawClapperEventArgs e);
        public event RawClapperEventHandler OnRawClapperEvent;

        public delegate void OnClapEventHandler(object sender, ClapperEventArgs e);
        public event OnClapEventHandler OnClap;

        public short UpperThreshold
        {
            get;
            set;
        }

        public short LowerThreshold
        {
            get;
            set;
        }

        public Clapper()
        {
            // for pumping XNA framework events
            t = new Timer()
            {
                Interval = 50,
            };

            t.Tick += new EventHandler(t_Tick);

            UpperThreshold = 3000;
            LowerThreshold = 800;
            state = ClapperState.WaitLow;

            eventWatch = new Stopwatch();

            window = new Queue<short>();

            m = Microphone.Default;
            buffer = new byte[m.GetSampleSizeInBytes(TimeSpan.FromMilliseconds(100))];

            m.BufferReady += new EventHandler<EventArgs>(m_BufferReady);
        }

        void t_Tick(object sender, EventArgs e)
        {
            FrameworkDispatcher.Update();
        }

	// This isn't great but the idea is that
	// there must be two peaks separated by more than 100ms
	// and those peaks must be within 1 second
        void StateCheck(short v)
        {
            if (eventWatch.ElapsedMilliseconds > 1000)
            {
                Debug.WriteLine("Timeout: Reset State");
                state = ClapperState.WaitLow;
                eventWatch.Reset();
            }

            switch (state)
            {
                case ClapperState.WaitLow:
                    if (v > UpperThreshold)
                    {
                        Debug.WriteLine("WL1 {0}", v);
                        state = ClapperState.WaitHigh;
                        eventWatch.Start();
                    }
                    break;
                case ClapperState.WaitHigh:
                    if (v < LowerThreshold &&
                        eventWatch.ElapsedMilliseconds > 50)
                    {
                        Debug.WriteLine("WH1 {0}", v);
                        state = ClapperState.WaitLow2;
                        eventWatch.Restart();
                    }
                    break;
                case ClapperState.WaitLow2:
                    if (v > UpperThreshold &&
                        eventWatch.ElapsedMilliseconds > 100)
                    {
                        Debug.WriteLine("WL2 {0}", v);
                        state = ClapperState.WaitHigh2;
                        eventWatch.Restart();
                    }
                    break;
                case ClapperState.WaitHigh2:
                    if (v < LowerThreshold &&
                        eventWatch.ElapsedMilliseconds > 50)
                    {
                        Debug.WriteLine("WH2 {0}", v);
                        state = ClapperState.WaitLow;
                        eventWatch.Reset();

                        if (OnClap != null)
                        {
                            OnClap(this, new ClapperEventArgs());
                        }
                    }
                    break;
            }
        }

        public void m_BufferReady(object sender, EventArgs e)
        {
            // data returned is 16 bit little endian PCM
            int count = m.GetData(this.buffer);
            short max = 0;
            int temp;

            for (int i = 0; i < count; i += 2 * 64 /* every 64th value */)
            {
                temp = BitConverter.ToInt16(buffer, i);
                temp = Math.Abs(temp);
                
                window.Enqueue((short)temp);
                while (window.Count > windowSize)
                {
                    window.Dequeue();
                }

                temp = (int)window.Average(s => s);
                StateCheck((short)temp);

                if (temp > max)
                {
                    max = (short)temp;
                }
            }

            if (OnRawClapperEvent != null)
            {
                OnRawClapperEvent(this, new RawClapperEventArgs() { Level = max });
            }
        }

        public void Arm()
        {
            t.Start();
            m.Start();
        }

        public void Disarm()
        {
            m.Stop();
            t.Stop();
        }
    }

    public class RawClapperEventArgs : EventArgs
    {
        public short Level
        {
            get;
            set;
        }
    }

    public class ClapperEventArgs : EventArgs
    {
    }
}
