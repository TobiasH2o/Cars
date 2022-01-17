using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class WeaponSlot : CarComponent
    {
        private List<Weapon> Weapons;

        public WeaponSlot(int Width, int Height, int Xpos, int Ypos, string Name, List<Weapon> Weapons) : base(Width, Height, Xpos, Ypos, Name)
        {
            this.Weapons = Weapons;
        }
    }
}