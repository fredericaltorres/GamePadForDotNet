﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

namespace WinGamePad.Lib
{
    /// <summary>
    /// http://sharpdx.org/
    /// https://stackoverflow.com/questions/3929764/taking-input-from-a-joystick-with-c-sharp-net
    /// </summary>
    public class GamePad
    {
        Joystick joystick;
        Guid joystickGuid = Guid.Empty;
        public GamePad()
        {

        }

        public List<JoystickUpdate>  GetData()
        {
            joystick.Poll();
            List<JoystickUpdate> datas = joystick.GetBufferedData().ToList();
            return datas;
        }

        protected bool AnalyseDataForButtons(List<JoystickUpdate> joystickUpdates, JoystickOffset offset, int value)
        {
            foreach(var ju in joystickUpdates)
            {
                if (ju.Offset == offset && ju.Value == value)
                    return true;
            }
            return false;
        }

        public class JoyStickXYZ
        {
            public int X;
            public int Y;
            public int Z;

            public JoyStickXYZ Clone()
            {
                return new JoyStickXYZ() { X  = this.X, Y = this.Y, Z = this.Z };
            }
            public override string ToString()
            {
                return $"X:{X:00000}, Y:{Y:00000}, Z:{Z:00000}";
            }
            public override bool Equals(object obj)
            {
                JoyStickXYZ o = obj as JoyStickXYZ;
                return this.X == o.X && this.Y == o.Y && this.Z == o.Z;
            }
        }

        private JoyStickXYZ _previousJoyStickXYZ = new JoyStickXYZ();

        public JoyStickXYZ AnalyseDataForXYJoyStick(List<JoystickUpdate> joystickUpdates)
        {
            JoyStickXYZ current = _previousJoyStickXYZ.Clone();
            foreach (var ju in joystickUpdates)
            {
                     if (ju.Offset == JoystickOffset.X) current.X = ju.Value;
                else if (ju.Offset == JoystickOffset.Y) current.Y = ju.Value;
                else if (ju.Offset == JoystickOffset.Z) current.Z = ju.Value;
            }

            if (current.Equals(this._previousJoyStickXYZ))
            {
                return null;
            }
            else
            {
                this._previousJoyStickXYZ = current;
                return current;
            }
        }

        public virtual bool Detect()
        {
            var directInput = new DirectInput();
            foreach (var deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                this.joystickGuid = deviceInstance.InstanceGuid;
            }
            if (this.joystickGuid == Guid.Empty)
                return false;

            this.joystick = new Joystick(directInput, joystickGuid);

            //var allEffects = joystick.GetEffects();
            //foreach (var effectInfo in allEffects)
            //    Console.WriteLine("Effect available {0}", effectInfo.Name);

            joystick.Properties.BufferSize = 128*256; // Set BufferSize in order to use buffered data.

            joystick.Acquire();

            return true;
        }
        public string Name
        {
            get
            {
                return this.joystick.Information.InstanceName;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            
            sb.Append($"Name:{this.Name}").Append(", ").AppendLine();
            sb.Append($"Type:{this.joystick.Information.Type}").Append(", ").AppendLine();
            sb.Append($"Subtype:{this.joystick.Information.Subtype}").Append(", ").AppendLine();
            sb.Append($"InstanceGuid:{this.joystick.Information.InstanceGuid}").Append(", ").AppendLine();
            sb.Append($"IsHumanInterfaceDevice:{this.joystick.Information.IsHumanInterfaceDevice}").Append(", ").AppendLine();

            return sb.ToString();
        }
    }
}
