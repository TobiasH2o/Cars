using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cars
{
    public partial class CarView : Form
    {
        private readonly Vehicle vehicle;
        private List<PictureBox> DamageSquares = new List<PictureBox>(50);

        public CarView(Vehicle vehicle)
        {
            this.vehicle = vehicle;
            InitializeComponent();
            DrawCar();
        }

        public void DrawCar()
        {
            DamageSquares.Clear();
            Controls.Clear();
            SuspendLayout();
            // Forward
            int xOffset = 50;
            int yOffset = 50;
            int SquareSize = 10;
            if (vehicle.For.End)
                for (int x = 0; x < vehicle.For.EndA.Width; x++)
                {
                    for (int y = 0; y < vehicle.For.EndA.Height; y++)
                    {
                        PictureBox square = new PictureBox();
                        square.BackColor = Color.RosyBrown;
                        square.Location = new Point((x * (SquareSize + SquareSize / 5)) + xOffset, (y * (SquareSize + SquareSize / 5)) + yOffset);
                        square.Size = new Size(SquareSize, SquareSize);
                        square.Visible = true;
                        Controls.Add(square);
                        DamageSquares.Add(square);
                    }
                }

            // Mid

            // Rear

            ResumeLayout(false);
        }
    }
}