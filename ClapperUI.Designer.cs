namespace ClapperApp
{
    partial class ClapperUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.onPic = new System.Windows.Forms.PictureBox();
            this.bgPic = new System.Windows.Forms.PictureBox();
            this.offPic = new System.Windows.Forms.PictureBox();
            this.delayTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.onPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offPic)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 596);
            this.progressBar1.Maximum = 32768;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(561, 10);
            this.progressBar1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(9, 570);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 20);
            this.textBox1.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(464, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(106, 104);
            this.listBox1.TabIndex = 6;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.SystemColors.WindowText;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.checkBox2.Location = new System.Drawing.Point(12, 12);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(46, 17);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Run";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(9, 609);
            this.progressBar2.Maximum = 32768;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(561, 10);
            this.progressBar2.TabIndex = 8;
            // 
            // onPic
            // 
            this.onPic.Image = global::ClapperApp.Properties.Resources.on;
            this.onPic.Location = new System.Drawing.Point(210, 66);
            this.onPic.Name = "onPic";
            this.onPic.Size = new System.Drawing.Size(158, 50);
            this.onPic.TabIndex = 9;
            this.onPic.TabStop = false;
            // 
            // bgPic
            // 
            this.bgPic.BackColor = System.Drawing.SystemColors.WindowText;
            this.bgPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bgPic.Image = global::ClapperApp.Properties.Resources.clapper;
            this.bgPic.Location = new System.Drawing.Point(0, 0);
            this.bgPic.Name = "bgPic";
            this.bgPic.Size = new System.Drawing.Size(582, 628);
            this.bgPic.TabIndex = 2;
            this.bgPic.TabStop = false;
            // 
            // offPic
            // 
            this.offPic.BackColor = System.Drawing.Color.Transparent;
            this.offPic.Image = global::ClapperApp.Properties.Resources.off;
            this.offPic.Location = new System.Drawing.Point(210, 122);
            this.offPic.Name = "offPic";
            this.offPic.Size = new System.Drawing.Size(158, 50);
            this.offPic.TabIndex = 10;
            this.offPic.TabStop = false;
            // 
            // delayTimer
            // 
            this.delayTimer.Interval = 2000;
            this.delayTimer.Tick += new System.EventHandler(this.delayTimer_Tick);
            // 
            // ClapperUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(582, 628);
            this.Controls.Add(this.offPic);
            this.Controls.Add(this.onPic);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bgPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClapperUI";
            this.Text = "The Clapper";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ClapperUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.onPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bgPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox bgPic;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.PictureBox onPic;
        private System.Windows.Forms.PictureBox offPic;
        private System.Windows.Forms.Timer delayTimer;
    }
}

