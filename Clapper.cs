using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Windows.Forms;

namespace ClapperApp
{
    class Clapper 
    {
        Timer t; // used for XNA Framework crap
        Microphone m;

        byte[] buffer;

        public delegate void RawClapperAudioLevel(short level);
        public event RawClapperAudioLevel OnAudioLevelUpdated;

        public Clapper()
        {
            t = new Timer()
            {
                Interval = 50,
            };

            t.Tick += new EventHandler(t_Tick);

            m = Microphone.Default;
            buffer = new byte[m.GetSampleSizeInBytes(TimeSpan.FromMilliseconds(100))];

            m.BufferReady += new EventHandler<EventArgs>(m_BufferReady);
        }

        void t_Tick(object sender, EventArgs e)
        {
            FrameworkDispatcher.Update();
        }

        public void m_BufferReady(object sender, EventArgs e)
        {
            // data returned is 16 bit little endian PCM
            int count = m.GetData(this.buffer);
            short max = 0;
            short temp;

            for (int i = 0; i < count; i += 2)
            {
                temp = BitConverter.ToInt16(buffer, i);

                if (temp > max)
                {
                    max = temp;
                }
            }

            if (OnAudioLevelUpdated != null)
            {
                OnAudioLevelUpdated(max);
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
}
