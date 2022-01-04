using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    internal class Component
    {
        public int TotalHealth { get; protected set; }
        public int DamagedHealth { get; protected set; }

        public bool Destroyed
        { get { return TotalHealth == DamagedHealth; } }

        public void Damage(int Damage)
        {
            if (!Destroyed)
            {
                DamagedHealth += Damage;
                if (DamagedHealth >= TotalHealth)
                    DamagedHealth = TotalHealth;
            }
        }

        public void Restore()
        {
            DamagedHealth = 0;
        }
    }
}