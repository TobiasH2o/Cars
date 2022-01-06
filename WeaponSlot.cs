using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class WeaponSlot : VisualComponent
    {
        public int Xpos { get; private set; }
        public int Ypos { get; private set; }

        public WeaponSlot(int Width, int Height, int Xpos, int Ypos) : base(Width, Height)
        {
            this.Xpos = Xpos;
            this.Ypos = Ypos;
        }
    }
}