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
         
        public ClapperUI()
        {
            InitializeComponent();
        }

        private void ClapperUI_Load(object sender, EventArgs e)
        {
            c = new Clapper();
            //c.OnRawClapperEvent += new Clapper.RawClapperEventHandler(c_OnAudioLevelUpdated);
            c.OnClap += new Clapper.OnClapEventHandler(c_OnClap);
        }

        void c_OnClap(object sender, ClapperEventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
            listBox1.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss.fff"));

            if (listBox1.Items.Count > 10)
            {
                listBox1.Items.RemoveAt(10);
            }

            SendKeys.Send(" ");
        }

        void c_OnAudioLevelUpdated(object sender, RawClapperEventArgs e)
        {
            progressBar1.Value = e.Level;
            textBox1.Text = e.Level.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Arm();
            checkBox2.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.Disarm();
            checkBox2.Checked = false;
        }
    }
}
