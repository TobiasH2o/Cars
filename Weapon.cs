using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Weapon : Component
    {
        private int MaximumDam { get; set; }
        private int MinimumDam { get; set; }

        public int Damage
        { get { return new Random().Next(MinimumDam, MaximumDam + 1); } set {; } }

        public Weapon(int MinimumDam, int MaximumDam, int Width, int Height) : base(Width, Height)
        {
            this.MaximumDam = MaximumDam;
            this.MinimumDam = MinimumDam;
        }
    }
}