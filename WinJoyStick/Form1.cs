using JoyStick.Lib;
using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinJoyStick
{
    public partial class Form1 : Form
    {
        JoyStick.Lib.LogitechF310GamePad logitechF310GamePad;

        Dictionary<LogitechF310GamePadFeatures, PictureBox> GamePadButtonToButtonRprMap
        {
            get
            {
                return new Dictionary<LogitechF310GamePadFeatures, PictureBox>() {
                    { LogitechF310GamePadFeatures.ButtonA, this.ButtonARpr},
                    { LogitechF310GamePadFeatures.ButtonB, this.ButtonBRpr},
                    { LogitechF310GamePadFeatures.ButtonX, this.ButtonXRpr},
                    { LogitechF310GamePadFeatures.ButtonY, this.ButtonYRpr},
                };
            }
        }

        public Form1()
        {
            
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            var datas = logitechF310GamePad.GetData();
            foreach(var button in logitechF310GamePad.GetButtons())
            {
                if (logitechF310GamePad.IsButtonPressedDown(datas, button))
                {
                    UserTrace($"Button {button} is pressed DOWN");
                    this.ActivateButton(GamePadButtonToButtonRprMap[button], true);
                }
                    
                if (logitechF310GamePad.IsButtonPressedUp(datas, button))
                {
                    UserTrace($"Button {button} is pressed UP");
                    this.ActivateButton(GamePadButtonToButtonRprMap[button], false);
                }
            }

            var joyStickXYZ = logitechF310GamePad.AnalyseDataForXYJoyStick(datas);
            if(joyStickXYZ != null)
                UserTrace($"XYZ {joyStickXYZ.ToString()}");

            //if (datas.Count > 0)
            //{
            //    foreach (var state in datas)
            //        UserTrace($"{state}", false);
            //    UserTrace("");
            //}
        }

        private void UserTrace(string m, bool refresh = true)
        {
            this.textBoxUserTrace.Text += $"{m}{Environment.NewLine}";
            if (refresh && this.textBoxUserTrace.Text.Length > 1)
            {
                this.textBoxUserTrace.SelectionStart = this.textBoxUserTrace.Text.Length;
                this.textBoxUserTrace.ScrollToCaret();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logitechF310GamePad = new JoyStick.Lib.LogitechF310GamePad();
            if (logitechF310GamePad.Detect())
            {
                UserTrace($"{logitechF310GamePad.Name} detected ");
                timer1.Enabled = true;
            }
            this.SetStatus("Ready...");
            this.Form1_Resize(sender, e);
            this.ButtonARpr.Tag = this.ButtonARpr.BackColor;
            this.ButtonBRpr.Tag = this.ButtonBRpr.BackColor;
            this.ButtonXRpr.Tag = this.ButtonXRpr.BackColor;
            this.ButtonYRpr.Tag = this.ButtonYRpr.BackColor;
        }

        private void SetStatus(string m)
        {
            toolStripStatusLabel1.Text = m;
            Application.DoEvents();
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.textBoxUserTrace.Left = 4;
            this.textBoxUserTrace.Width = this.Width - 24;
            this.textBoxUserTrace.Top = this.fileToolStripMenuItem.Height + 4;
            this.textBoxUserTrace.Height = this.Height - this.statusStrip1.Height - 64 - 8;
        }

        private void ActivateButton(PictureBox b, bool on)
        {
            if (on)
                b.BackColor = Color.White;
            else
                b.BackColor = (Color)b.Tag;
        }
    }
}
