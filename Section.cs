using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Section
    {
        public bool End;
        public int Width;
        public int Height;
        public Armour LeftA;
        public Armour RightA;
        public Armour EndA;
        public Wheel LeftW;
        public Wheel RightW;
        public List<WeaponSlot> Weapons;

        public Section(Tuple<int, int> LeftA, Tuple<int, int> RightA, Tuple<int, int, double> LeftW = null, Tuple<int, int, double> RightW = null, Tuple<int, int> EndA = null, int? Width = null, List<WeaponSlot> Weapons = null, int? Height = null)
        {
            EndA = EndA ?? new Tuple<int, int>(0, 0);
            LeftW = LeftW ?? new Tuple<int, int, double>(0, 0, 0);
            RightW = RightW ?? new Tuple<int, int, double>(0, 0, 0);
            Weapons = Weapons ?? new List<WeaponSlot>(0);
            End = !(EndA.Item1 == 0 || EndA.Item2 == 0);
            this.LeftA = new Armour(LeftA.Item1, LeftA.Item2);
            this.RightA = new Armour(RightA.Item1, RightA.Item2);
            this.EndA = new Armour(EndA.Item1, EndA.Item2);
            this.LeftW = new Wheel(LeftW.Item1, LeftW.Item2, LeftW.Item3);
            this.RightW = new Wheel(RightW.Item1, RightW.Item2, RightW.Item3);
            this.Width = Width ?? (Math.Max(LeftA.Item1, RightA.Item1) + this.EndA.Width);
            this.Height = Height ?? Math.Max(this.LeftA.Height, Math.Max(this.RightA.Height, this.EndA.Height));
            this.Weapons = Weapons;
        }
    }
}