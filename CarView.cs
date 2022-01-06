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
        private static readonly int WIDTH = 1;
        private static readonly int HEIGHT = 1;

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
            // Armour
            Controls.Clear();
            int DefaultY = (Height / 2) - ((vehicle.For.EndA.Height * (SquareSize + SquareSize / SquareSpacing)) / 2) - SquareSize / 2;
            int yOffset = DefaultY;
            int xOffset = EdgeSpacing;
            // Forward
            InitializeVisualComponent(vehicle.For.EndA, vehicle.Height, 0, xOffset, yOffset);
            // Right
            xOffset += vehicle.For.EndA.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeVisualComponent(vehicle.For.RightA, vehicle.For.Width, 1, xOffset, yOffset);
            // Left
            yOffset += (vehicle.For.EndA.Height - vehicle.For.LeftA.Height) * (SquareSize + SquareSize / SquareSpacing);
            InitializeVisualComponent(vehicle.For.LeftA, vehicle.For.Width, 1, xOffset, yOffset);
            // Mid
            xOffset += vehicle.For.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeVisualComponent(vehicle.Mid.RightA, vehicle.Mid.Width, 1, xOffset, DefaultY);
            InitializeVisualComponent(vehicle.Mid.LeftA, vehicle.Mid.Width, 1, xOffset, yOffset);
            // Rear
            xOffset += vehicle.Mid.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeVisualComponent(vehicle.Rear.RightA, vehicle.Rear.Width, 1, xOffset, DefaultY);
            InitializeVisualComponent(vehicle.Rear.LeftA, vehicle.Rear.Width, 1, xOffset, yOffset);
            xOffset += vehicle.Rear.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeVisualComponent(vehicle.Rear.EndA, vehicle.Height, 0, xOffset, DefaultY);

            // Weapons

            // Forward
            xOffset = EdgeSpacing + (vehicle.For.EndA.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing);
            yOffset = vehicle.For.RightA.Height * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;

            foreach (WeaponSlot Slot in vehicle.For.Weapons)
            {
                InitializeVisualComponent(Slot, Slot.Width, WIDTH, xOffset, yOffset);
            }

            // Forward weapons
        }

        private void InitializeVisualComponent(VisualComponent component, int targetLength, int targetDirection, int xOffset, int yOffset)
        {
            int SquareCount = 0;
            component.ClearHealthSquares();
            if (targetDirection == WIDTH)
                xOffset += (targetLength - component.Width) * (SquareSize + SquareSize / SquareSpacing) / 2;
            else
                yOffset += (targetLength - component.Height) * (SquareSize + SquareSize / SquareSpacing) / 2;
            for (int x = 0; x < component.Width; x++)
            {
                for (int y = 0; y < component.Height; y++)
                {
                    PictureBox square = new PictureBox();
                    if (SquareCount < component.DamagedHealth)
                        square.BackColor = Color.RosyBrown;
                    else square.BackColor = Color.GhostWhite;
                    SquareCount++;
                    square.Location = new Point((x * (SquareSize + SquareSize / SquareSpacing)) + xOffset, (y * (SquareSize + SquareSize / SquareSpacing)) + yOffset);
                    square.Size = new Size(SquareSize, SquareSize);
                    square.Visible = true;
                    Controls.Add(square);
                    component.AddHealthSquare(square);
                }
            }
        }
    }
}