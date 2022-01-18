using System.Collections.Generic;

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