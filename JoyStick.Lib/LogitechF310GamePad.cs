using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace JoyStick.Lib
{
    public enum LogitechF310GamePadFeatures
    {
        ButtonX,
        ButtonY,
        ButtonA,
        ButtonB,
    };

    /// <summary>
    /// http://sharpdx.org/
    /// https://stackoverflow.com/questions/3929764/taking-input-from-a-joystick-with-c-sharp-net
    /// </summary>
    public class LogitechF310GamePad : GamePad
    {
        const int BUTTON_PRESSED_DOWN_VALUE = 128;
        const int BUTTON_PRESSED_UP_VALUE = 0;

        private Dictionary<LogitechF310GamePadFeatures, JoystickOffset> ButtonMapping = new Dictionary<LogitechF310GamePadFeatures, JoystickOffset>()
        {
            { LogitechF310GamePadFeatures.ButtonA, JoystickOffset.Buttons0  },
            { LogitechF310GamePadFeatures.ButtonB, JoystickOffset.Buttons1  },
            { LogitechF310GamePadFeatures.ButtonX , JoystickOffset.Buttons2 },
            { LogitechF310GamePadFeatures.ButtonY , JoystickOffset.Buttons3 },
        };
               
        public LogitechF310GamePad()
        {

        }

        public List<LogitechF310GamePadFeatures> GetButtons()
        {
            return Enum.GetValues(typeof(LogitechF310GamePadFeatures)).Cast<LogitechF310GamePadFeatures>().ToList();
        }

        public bool IsButtonPressedDown(List<JoystickUpdate> joystickUpdates, LogitechF310GamePadFeatures button)
        {
            return base.AnalyseDataForButtons(joystickUpdates, ButtonMapping[button], BUTTON_PRESSED_DOWN_VALUE);
        }

        public bool IsButtonPressedUp(List<JoystickUpdate> joystickUpdates, LogitechF310GamePadFeatures button)
        {
            return base.AnalyseDataForButtons(joystickUpdates, ButtonMapping[button], BUTTON_PRESSED_UP_VALUE);
        }

        public override bool Detect()
        {
            if(base.Detect())
                return this.Name.Contains("F310");
            else
                return false;
        }
    }
}

