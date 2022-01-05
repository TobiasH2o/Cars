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
        private int EdgeSpacing = 25;
        private int SquareSize = 18;
        private int SquareSpacing = 5;
        private int SectorSpacing = 2;

        public CarView(Vehicle vehicle)
        {
            this.vehicle = vehicle;
            InitializeComponent();
            CalculateSquareSize();
            InitialRender();
        }

        public void CalculateSquareSize()
        {
            int CarWidth = vehicle.Width;
            int CarHeight = vehicle.Height;
            int SquareTest = 2;
            int HeightLimit = Height;
            int WidthLimit = Width;

            while (CarHeight * (SquareTest + SquareTest / SquareSpacing) + EdgeSpacing < HeightLimit && CarWidth * (SquareTest + SquareTest / SquareSpacing) + 2 * (SquareTest / SectorSpacing) < WidthLimit)
                SquareTest += 2;
            SquareTest -= 2;

            if (SquareTest == 0) SquareSize = 1;
            else SquareSize = SquareTest;
        }

        public void InitialRender()
        {
            Controls.Clear();
            // Forward
            int DefaultY = (Height / 2) - ((vehicle.For.EndA.Height * (SquareSize + SquareSize / SquareSpacing)) / 2) - SquareSize / 2;
            int yOffset = DefaultY;
            int xOffset = EdgeSpacing;
            // Forward
            if (vehicle.For.End)
                InitializeArmour(vehicle.For.EndA, xOffset, yOffset);
            // Right
            xOffset += vehicle.For.EndA.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeArmour(vehicle.For.RightA, xOffset, yOffset);
            // Left
            yOffset += (vehicle.For.EndA.Height - vehicle.For.LeftA.Height) * (SquareSize + SquareSize / SquareSpacing);
            InitializeArmour(vehicle.For.LeftA, xOffset, yOffset);
            // Mid
            xOffset += vehicle.For.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeArmour(vehicle.Mid.RightA, xOffset, DefaultY);
            InitializeArmour(vehicle.Mid.LeftA, xOffset, yOffset);
            // Rear
            xOffset += vehicle.Mid.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeArmour(vehicle.Rear.RightA, xOffset, DefaultY);
            InitializeArmour(vehicle.Rear.LeftA, xOffset, yOffset);
            xOffset += vehicle.Rear.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeArmour(vehicle.Rear.EndA, xOffset, DefaultY);
        }

        private void InitializeArmour(Armour armour, int xOffset, int yOffset)
        {
            int SquareCount = 0;
            armour.ClearHealthSquares();
            for (int x = 0; x < armour.Width; x++)
            {
                for (int y = 0; y < armour.Height; y++)
                {
                    PictureBox square = new PictureBox();
                    if (SquareCount < armour.DamagedHealth)
                        square.BackColor = Color.RosyBrown;
                    else square.BackColor = Color.GhostWhite;
                    SquareCount++;
                    square.Location = new Point((x * (SquareSize + SquareSize / SquareSpacing)) + xOffset, (y * (SquareSize + SquareSize / SquareSpacing)) + yOffset);
                    square.Size = new Size(SquareSize, SquareSize);
                    square.Visible = true;
                    Controls.Add(square);
                    armour.AddHealthSquare(square);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            vehicle.For.EndA.Damage(0.5);
        }
    }
}