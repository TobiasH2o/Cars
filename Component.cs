using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Component
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public int TotalHealth
        { get { return Width * Height; } }

        public double DamagedHealth { get; protected set; }

        public bool Destroyed
        { get { return TotalHealth == DamagedHealth; } }

        public Component(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public void Damage(double Damage)
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