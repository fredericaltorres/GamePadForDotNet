using WinGamePad.Lib;
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
using System.Media;

namespace WinJoyStick
{
    public partial class Form1 : Form
    {
        WinGamePad.Lib.LogitechF310GamePad logitechF310GamePad;
        SoundManager _soundManager;
        PictureBox _activePictureBox = null;
        string _activeText = null;

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

            var joyStickXYZ = logitechF310GamePad.AnalyseDataForXYZJoyStick(datas);
            if(joyStickXYZ != null)
                UserTrace($"XYZ {joyStickXYZ.ToString()}");

            var rotationJoyStickXYZ = logitechF310GamePad.AnalyseDataForRotationJoyStickXYZ(datas);
            if (rotationJoyStickXYZ != null)
                UserTrace($"Rotation XYZ {rotationJoyStickXYZ.ToString()}");

            if (this.ViewRawData)
            {
                if (datas.Count > 0)
                {
                    foreach (var state in datas)
                        UserTrace($"{state}", false);
                    UserTrace("");
                }
            }
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
            logitechF310GamePad = new WinGamePad.Lib.LogitechF310GamePad();
            if (logitechF310GamePad.Detect())
            {
                UserTrace($"{logitechF310GamePad.Name} detected ");
                timer1.Enabled = true;
            }
            else
            {
                UserTrace($"No GamePad detected ");
            }
            this.SetStatus("Ready...");
            this.Form1_Resize(sender, e);
            this.ButtonARpr.Tag = this.ButtonARpr.BackColor;
            this.ButtonBRpr.Tag = this.ButtonBRpr.BackColor;
            this.ButtonXRpr.Tag = this.ButtonXRpr.BackColor;
            this.ButtonYRpr.Tag = this.ButtonYRpr.BackColor;

            this._soundManager = new SoundManager();
            this._soundManager.Add(this.ButtonARpr, @".\Wav\Yes.wav");
            this._soundManager.Add(this.ButtonBRpr, @".\Wav\No.wav");
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
            {
                b.BackColor = Color.White;
                if (this._soundManager.Contains(b))
                {
                    this._activeText = this._soundManager.GetText(b);
                    this._activePictureBox = b;
                    b.Refresh();
                    this._soundManager.Play(b);
                }
            }
            else
            {
                b.BackColor = (Color)b.Tag;
                if (this._soundManager.Contains(b))
                {
                    this._activeText = null;
                    this._activePictureBox = null;
                    b.Refresh();
                }
            }
        }

        private void ShowRawDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this.Text  = $"{showRawDataToolStripMenuItem.Checked}";
        }

        private bool ViewRawData {
            get
            {
                return this.showRawDataToolStripMenuItem.Checked;
            }
        }

        private void ButtonGenericRpr_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as PictureBox;
            if (this._activePictureBox == p)
            {
                using (Font myFont = new Font("Arial", 14))
                {
                    e.Graphics.DrawString(this._activeText, myFont, Brushes.Black, new Point(1, 1));
                }
            }
        }
    }
}
