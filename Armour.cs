using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    internal class Armour : Component
    {
        public static int FORWARD = 0;
        public static int LEFT = 1;
        public static int BACK = 2;
        public static int RIGHT = 3;
        public readonly int Side;

        public Armour(int health, int Side)
        {
            TotalHealth = health;
            this.Side = Side;
        }
    }
}