﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cars
{
    public partial class CarView : Form
    {
        private readonly Vehicle vehicle;
        private int InitX = 0;
        private int InitY = 0;
        private int SquareSize = 18;
        private int SquareSpacing = 5;
        private int SectorSpacing = 3;
        private int BufferSize = 1;
        private static readonly int WIDTH = 1;
        private static readonly int HEIGHT = 0;

        public CarView(Vehicle vehicle)
        {
            this.vehicle = vehicle;
            InitializeComponent();
            RenderVehicle();
        }

        public void CalculateSquareSize()
        {
            int.TryParse(BufferSizeBox.Text, out int i);
            if (i <= 0) BufferSizeBox.Text = BufferSize.ToString();
            else BufferSize = i;
            int CarWidth = vehicle.Width;
            int CarHeight = vehicle.Height;
            int SquareTest = 2;
            int HeightLimit = VehicleBox.Height - BufferSize;
            int WidthLimit = VehicleBox.Width - BufferSize;

            while (CarHeight * (SquareTest + SquareTest / SquareSpacing) < HeightLimit && CarWidth * (SquareTest + SquareTest / SquareSpacing) + 2 * (SquareTest / SectorSpacing) < WidthLimit)
                SquareTest += 2;
            SquareTest -= 4;

            if (SquareTest == 0) SquareSize = 1;
            else SquareSize = SquareTest;

            InitX = (WidthLimit / 2 - (CarWidth * (SquareTest + SquareTest / SquareSpacing) / 2 + 2 * (SquareTest / SectorSpacing)));
            InitY = (HeightLimit / 2 - CarHeight * (SquareTest + SquareTest / SquareSpacing) / 2);
        }

        public void RenderVehicle()
        {
            CalculateSquareSize();
            // Armour
            VehicleBox.Controls.Clear();
            int yOffset = InitY;
            int xOffset = InitX;
            double BlocksPlaced = 0;
            // Forward
            InitializeVisualComponent(vehicle.For.EndA, vehicle.Height, HEIGHT, xOffset, yOffset);
            xOffset += vehicle.For.EndA.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeVisualComponent(vehicle.For.RightA, vehicle.For.Width - vehicle.For.EndA.Width, WIDTH, xOffset, yOffset);
            yOffset += (vehicle.For.Height - vehicle.For.LeftA.Height) * (SquareSize + SquareSize / SquareSpacing);
            InitializeVisualComponent(vehicle.For.LeftA, vehicle.For.Width - vehicle.For.EndA.Width, WIDTH, xOffset, yOffset);
            BlocksPlaced += vehicle.For.Width + 2.00d / SectorSpacing;
            // Mid
            xOffset = (int)(InitX + BlocksPlaced * (SquareSize + SquareSize / SquareSpacing));
            InitializeVisualComponent(vehicle.Mid.RightA, vehicle.Mid.Width, WIDTH, xOffset, InitY);
            InitializeVisualComponent(vehicle.Mid.LeftA, vehicle.Mid.Width, WIDTH, xOffset, yOffset);
            BlocksPlaced += vehicle.Mid.Width + 1.00d / SectorSpacing;
            // Rear
            xOffset = (int)(InitX + BlocksPlaced * (SquareSize + SquareSize / SquareSpacing));
            InitializeVisualComponent(vehicle.Rear.RightA, vehicle.Rear.Width - vehicle.Rear.EndA.Width, WIDTH, xOffset, InitY);
            InitializeVisualComponent(vehicle.Rear.LeftA, vehicle.Rear.Width - vehicle.Rear.EndA.Width, WIDTH, xOffset, yOffset);
            xOffset += (vehicle.Rear.Width - vehicle.Rear.EndA.Width) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeVisualComponent(vehicle.Rear.EndA, vehicle.Height, HEIGHT, xOffset, InitY);

            // WeaponSlots

            // Forward
            xOffset = InitX + (vehicle.For.EndA.Width) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            yOffset = InitY + (vehicle.Mid.RightA.Height) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            foreach (CarComponent Slot in vehicle.For.WeaponSlots)
            {
                int xPosition = (Slot.Xpos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                int yPosition = (Slot.Ypos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                InitializeVisualComponent(Slot, Slot.Width, WIDTH, xOffset + xPosition, yOffset + yPosition);
            }
            // Mid
            xOffset = InitX + (vehicle.For.Width) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            yOffset = InitY + vehicle.Mid.RightA.Height * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            foreach (CarComponent Slot in vehicle.Mid.WeaponSlots)
            {
                int xPosition = (Slot.Xpos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                int yPosition = (Slot.Ypos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                InitializeVisualComponent(Slot, Slot.Width, WIDTH, xOffset + xPosition, yOffset + yPosition);
            }
            // Rear
            xOffset = InitX + (vehicle.Mid.Width + vehicle.For.Width) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            yOffset = InitY + vehicle.Rear.RightA.Height * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            foreach (CarComponent Slot in vehicle.Rear.WeaponSlots)
            {
                int xPosition = (Slot.Xpos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                int yPosition = (Slot.Ypos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                InitializeVisualComponent(Slot, Slot.Width, WIDTH, xOffset + xPosition, yOffset + yPosition);
            }
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
                    VehicleBox.Controls.Add(square);
                    component.AddHealthSquare(square);
                }
            }
            if (component.Named)
            {
                Label Label = new Label();
                Label.Text = component.Name;
                Label.Location = new Point(xOffset + (component.Width * (SquareSize + SquareSize / SquareSpacing) / 2 - Label.PreferredWidth / 2), yOffset + (component.Height * (SquareSize + SquareSize / SquareSpacing)));
                Label.Visible = true;
                VehicleBox.Controls.Add(Label);
            }
            PictureBox Background = new PictureBox();
            Background.BackColor = Color.DarkSlateGray;
            Background.Location = new Point(xOffset - SquareSize / (4 * SectorSpacing), yOffset - SquareSize / (4 * SectorSpacing));
            Background.Size = new Size(component.Width * (SquareSize + SquareSize / SquareSpacing), component.Height * (SquareSize + SquareSize / SquareSpacing));
            Background.Visible = true;
            VehicleBox.Controls.Add(Background);
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            RenderVehicle();
        }
    }
}