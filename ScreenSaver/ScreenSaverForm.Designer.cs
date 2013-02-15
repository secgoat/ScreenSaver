using System.Windows.Forms;
namespace ScreenSaver
{
    partial class ScreenSaverForm
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
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.wordTimer = new System.Windows.Forms.Timer(this.components);
            this.heart = new System.Windows.Forms.PictureBox();
            this.Link = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.heart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "I LOVE YOU!";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // wordTimer
            // 
            this.wordTimer.Interval = 3000;
            this.wordTimer.Tick += new System.EventHandler(this.wordTimer_Tick);
            // 
            // heart
            // 
            this.heart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.heart.Image = global::ScreenSaver.Properties.Resources.heart;
            this.heart.Location = new System.Drawing.Point(1, 114);
            this.heart.Name = "heart";
            this.heart.Size = new System.Drawing.Size(35, 35);
            this.heart.TabIndex = 1;
            this.heart.TabStop = false;
            // 
            // Link
            // 
            this.Link.Image = global::ScreenSaver.Properties.Resources.down;
            this.Link.Location = new System.Drawing.Point(119, 114);
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(32, 35);
            this.Link.TabIndex = 1;
            this.Link.TabStop = false;
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.heart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Link);
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ScreenSaver";
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenSaverForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.heart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Link)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.PictureBox Link;
        private PictureBox heart;
        private Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Timer wordTimer;
    }
}

