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
            c.OnAudioLevelUpdated += new Clapper.RawClapperAudioLevel(c_OnAudioLevelUpdated);
        }

        void c_OnAudioLevelUpdated(short level)
        {
            progressBar1.Value = level;
            textBox1.Text = level.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Arm();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.Disarm();
        }
    }
}
