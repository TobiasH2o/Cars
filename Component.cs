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

        private bool[][] HealthGrid;

        public Component(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            HealthGrid = new bool[Width][];
            for (int i = 0; i < Width; i++)
            {
                HealthGrid[i] = new bool[Height];
                for (int j = 0; j < Height; j++)
                {
                    HealthGrid[i][j] = false;
                }
            }
        }

        public bool SectionDamaged(int x, int y)
        {
            return HealthGrid[x][y];
        }

        public void Damage(double Damage)
        {
            if (!Destroyed)
            {
                DamagedHealth += Damage;
                if (DamagedHealth >= TotalHealth)
                    DamagedHealth = TotalHealth;
            }
            for (int i = (int)(DamagedHealth - Damage); i < DamagedHealth; i++)
            {
                HealthGrid[i % Width][i / Height] = true;
            }
        }

        public void Restore()
        {
            DamagedHealth = 0;
        }
    }
}