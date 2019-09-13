namespace WinGamePad.Lib
{
    public partial class GamePad
    {
        public class JoyStickXYZ
        {
            public int X;
            public int Y;
            public int Z;

            public JoyStickXYZ Clone()
            {
                return new JoyStickXYZ() { X  = this.X, Y = this.Y, Z = this.Z };
            }

            public int X0
            {
                get {
                    return this.X - short.MaxValue - 128;
                }
            }
            public int Y0
            {
                get
                {
                    return this.Y - short.MaxValue + 129 ;
                }
            }
            public int Z0
            {
                get
                {
                    return this.Z - short.MaxValue ;
                }
            }
            public override string ToString()
            {
                return $"X:{X:00000}, Y:{Y:00000}, Z:{Z:00000} - X:{X0:00000}, Y:{Y0:00000}, Z:{Z0:00000}";
            }
            public override bool Equals(object obj)
            {
                JoyStickXYZ o = obj as JoyStickXYZ;
                return this.X == o.X && this.Y == o.Y && this.Z == o.Z;
            }
        }
    }
}
