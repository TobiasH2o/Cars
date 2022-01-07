using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class WeaponSlot : CarComponent
    {
        public WeaponSlot(int Width, int Height, int Xpos, int Ypos, string Name) : base(Width, Height, Xpos, Ypos, Name)
        {
        }
    }
}