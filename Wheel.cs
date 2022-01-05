using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    internal class Wheel : Component
    {
        public double SpeedModifier { get; protected set; }

        public Wheel(int Width, int Height, double SpeedModifier) : base(Width, Height)
        {
            this.SpeedModifier = SpeedModifier;
        }
    }
}