namespace WinJoyStick
{
    partial class Form1
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBoxUserTrace = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ButtonXRpr = new System.Windows.Forms.PictureBox();
            this.ButtonBRpr = new System.Windows.Forms.PictureBox();
            this.ButtonYRpr = new System.Windows.Forms.PictureBox();
            this.ButtonARpr = new System.Windows.Forms.PictureBox();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRawDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonXRpr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonBRpr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonYRpr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonARpr)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 32;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // textBoxUserTrace
            // 
            this.textBoxUserTrace.Location = new System.Drawing.Point(83, 84);
            this.textBoxUserTrace.Multiline = true;
            this.textBoxUserTrace.Name = "textBoxUserTrace";
            this.textBoxUserTrace.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxUserTrace.Size = new System.Drawing.Size(1428, 772);
            this.textBoxUserTrace.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(2507, 56);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(103, 52);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(414, 66);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1168);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(2507, 63);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(354, 48);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ButtonXRpr
            // 
            this.ButtonXRpr.BackColor = System.Drawing.Color.RoyalBlue;
            this.ButtonXRpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonXRpr.Location = new System.Drawing.Point(1858, 345);
            this.ButtonXRpr.Name = "ButtonXRpr";
            this.ButtonXRpr.Size = new System.Drawing.Size(274, 218);
            this.ButtonXRpr.TabIndex = 4;
            this.ButtonXRpr.TabStop = false;
            this.ButtonXRpr.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonGenericRpr_Paint);
            // 
            // ButtonBRpr
            // 
            this.ButtonBRpr.BackColor = System.Drawing.Color.Crimson;
            this.ButtonBRpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonBRpr.Location = new System.Drawing.Point(2177, 345);
            this.ButtonBRpr.Name = "ButtonBRpr";
            this.ButtonBRpr.Size = new System.Drawing.Size(274, 218);
            this.ButtonBRpr.TabIndex = 5;
            this.ButtonBRpr.TabStop = false;
            this.ButtonBRpr.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonGenericRpr_Paint);
            // 
            // ButtonYRpr
            // 
            this.ButtonYRpr.BackColor = System.Drawing.Color.Gold;
            this.ButtonYRpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonYRpr.Location = new System.Drawing.Point(2025, 96);
            this.ButtonYRpr.Name = "ButtonYRpr";
            this.ButtonYRpr.Size = new System.Drawing.Size(274, 218);
            this.ButtonYRpr.TabIndex = 6;
            this.ButtonYRpr.TabStop = false;
            this.ButtonYRpr.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonGenericRpr_Paint);
            // 
            // ButtonARpr
            // 
            this.ButtonARpr.BackColor = System.Drawing.Color.ForestGreen;
            this.ButtonARpr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ButtonARpr.Location = new System.Drawing.Point(2025, 592);
            this.ButtonARpr.Name = "ButtonARpr";
            this.ButtonARpr.Size = new System.Drawing.Size(274, 218);
            this.ButtonARpr.TabIndex = 7;
            this.ButtonARpr.TabStop = false;
            this.ButtonARpr.Paint += new System.Windows.Forms.PaintEventHandler(this.ButtonGenericRpr_Paint);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRawDataToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(124, 57);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showRawDataToolStripMenuItem
            // 
            this.showRawDataToolStripMenuItem.CheckOnClick = true;
            this.showRawDataToolStripMenuItem.Name = "showRawDataToolStripMenuItem";
            this.showRawDataToolStripMenuItem.Size = new System.Drawing.Size(538, 66);
            this.showRawDataToolStripMenuItem.Text = "Show Raw Data";
            this.showRawDataToolStripMenuItem.Click += new System.EventHandler(this.ShowRawDataToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2507, 1231);
            this.Controls.Add(this.ButtonARpr);
            this.Controls.Add(this.ButtonYRpr);
            this.Controls.Add(this.ButtonBRpr);
            this.Controls.Add(this.ButtonXRpr);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.textBoxUserTrace);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Game Pad";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonXRpr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonBRpr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonYRpr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonARpr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBoxUserTrace;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.PictureBox ButtonXRpr;
        private System.Windows.Forms.PictureBox ButtonBRpr;
        private System.Windows.Forms.PictureBox ButtonYRpr;
        private System.Windows.Forms.PictureBox ButtonARpr;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showRawDataToolStripMenuItem;
    }
}

