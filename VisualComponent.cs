using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars
{
    public class VisualComponent : Component
    {
        private List<PictureBox> HealthSquares;

        public VisualComponent(int width, int height) : base(width, height)
        {
            HealthSquares = new List<PictureBox>(width * height);
        }

        public new void Damage(double DamageDealt)
        {
            base.Damage(DamageDealt);
            for (int i = 0; i < DamagedHealth; i++)
                HealthSquares[i].BackColor = Color.RosyBrown;
            for (int i = (int)DamagedHealth; i < TotalHealth; i++)
                HealthSquares[i].BackColor = Color.GhostWhite;
        }

        public new void Restore()
        {
            base.Restore();
            Damage(0);
        }

        public void AddHealthSquare(PictureBox NewSquare)
        {
            HealthSquares.Add(NewSquare);
        }

        public void ClearHealthSquares()
        {
            HealthSquares.Clear();
        }
    }
}