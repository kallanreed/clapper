using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClapperApp
{
    public partial class ClapperUI : Form
    {
        Clapper c;
        int max = 0;
        bool clapOn = false;
         
        public ClapperUI()
        {
            InitializeComponent();
            HidePics();
        }

        private void ClapperUI_Load(object sender, EventArgs e)
        {
            c = new Clapper();
            c.OnRawClapperEvent += new Clapper.RawClapperEventHandler(c_OnAudioLevelUpdated);
            c.OnClap += new Clapper.OnClapEventHandler(c_OnClap);
        }

        private void HidePics()
        {
            onPic.Visible = false;
            offPic.Visible = false;
            delayTimer.Stop();
        }

        void c_OnClap(object sender, ClapperEventArgs e)
        {
            // add a clap list entry for debug
            listBox1.Items.Insert(0, DateTime.Now.ToString("mm:ss.fff"));
            if (listBox1.Items.Count > 5)
            {
                listBox1.Items.RemoveAt(5);
            }

            // set up clap on/off state
            HidePics();
            clapOn = !clapOn;

            if (clapOn)
            {
                onPic.Visible = true;
            }
            else
            {
                offPic.Visible = true;
            }
            delayTimer.Start();

            // send key (to advance deck)
            SendKeys.Send(" ");
        }

        void c_OnAudioLevelUpdated(object sender, RawClapperEventArgs e)
        {
            progressBar1.Value = e.Level;

            if (e.Level > max)
            {
                max = e.Level;
                textBox1.Text = max.ToString();
                progressBar2.Value = e.Level;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                c.Arm();
                max = 0;
                progressBar1.Value = 0;
                progressBar2.Value = 0;
                listBox1.Items.Clear();
                textBox1.Clear();
            }
            else
            {
                c.Disarm();
            }
        }

        private void delayTimer_Tick(object sender, EventArgs e)
        {
            HidePics();
        }
    }
}
