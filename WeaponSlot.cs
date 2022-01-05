using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    internal class WeaponSlot : Component
    {
        public bool traps { get; protected set; }
        public bool turret { get; protected set; }

        public WeaponSlot(int Width, int Height) : base(Width, Height)
        {
        }
    }
}