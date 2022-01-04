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

        public Wheel(int SpeedModifier, int width, int height)
        {
        }
    }
}