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

        private void VehicleBox_Paint(object sender, PaintEventArgs e)
        {
            RenderVehicle(e.Graphics);
        }

        public void RenderVehicle(Graphics g)
        {
            CalculateSquareSize();
            // Armour
            VehicleBox.Controls.Clear();
            int yOffset = InitY;
            int xOffset = InitX;
            double BlocksPlaced = 0;
            // Forward
            InitializeVisualComponent(vehicle.For.EndA, vehicle.Height, HEIGHT, xOffset, yOffset, g);
            xOffset += vehicle.For.EndA.Width * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeVisualComponent(vehicle.For.RightA, vehicle.For.Width - vehicle.For.EndA.Width, WIDTH, xOffset, yOffset, g);
            yOffset += (vehicle.For.Height - vehicle.For.LeftA.Height) * (SquareSize + SquareSize / SquareSpacing);
            InitializeVisualComponent(vehicle.For.LeftA, vehicle.For.Width - vehicle.For.EndA.Width, WIDTH, xOffset, yOffset, g);
            BlocksPlaced += vehicle.For.Width + 2.50d / SectorSpacing;
            int MiddlePoint = (int)(InitX + (BlocksPlaced - (1.1d / SectorSpacing)) * (SquareSize + (SquareSize / SquareSpacing)));
            g.DrawLine(new Pen(Color.Black, 1), MiddlePoint, 0, MiddlePoint, Height);
            // Mid
            xOffset = (int)(InitX + BlocksPlaced * (SquareSize + SquareSize / SquareSpacing));
            InitializeVisualComponent(vehicle.Mid.RightA, vehicle.Mid.Width, WIDTH, xOffset, InitY, g);
            InitializeVisualComponent(vehicle.Mid.LeftA, vehicle.Mid.Width, WIDTH, xOffset, yOffset, g);
            BlocksPlaced += vehicle.Mid.Width + 1.00d / SectorSpacing;
            BlocksPlaced += 1;
            // Rear
            xOffset = (int)(InitX + BlocksPlaced * (SquareSize + SquareSize / SquareSpacing));
            InitializeVisualComponent(vehicle.Rear.RightA, vehicle.Rear.Width - vehicle.Rear.EndA.Width, WIDTH, xOffset, InitY, g);
            InitializeVisualComponent(vehicle.Rear.LeftA, vehicle.Rear.Width - vehicle.Rear.EndA.Width, WIDTH, xOffset, yOffset, g);
            xOffset += (vehicle.Rear.Width - vehicle.Rear.EndA.Width) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            InitializeVisualComponent(vehicle.Rear.EndA, vehicle.Height, HEIGHT, xOffset, InitY, g);

            // WeaponSlots

            // Forward
            xOffset = InitX + (vehicle.For.EndA.Width) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            yOffset = InitY + (vehicle.Mid.RightA.Height) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            foreach (CarComponent Slot in vehicle.For.WeaponSlots)
            {
                int xPosition = (Slot.Xpos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                int yPosition = (Slot.Ypos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                InitializeVisualComponent(Slot, Slot.Width, WIDTH, xOffset + xPosition, yOffset + yPosition, g);
            }
            // Mid
            xOffset = InitX + (vehicle.For.Width) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            yOffset = InitY + vehicle.Mid.RightA.Height * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            foreach (CarComponent Slot in vehicle.Mid.WeaponSlots)
            {
                int xPosition = (Slot.Xpos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                int yPosition = (Slot.Ypos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                InitializeVisualComponent(Slot, Slot.Width, WIDTH, xOffset + xPosition, yOffset + yPosition, g);
            }
            // Rear
            xOffset = InitX + (vehicle.Mid.Width + vehicle.For.Width) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            yOffset = InitY + vehicle.Rear.RightA.Height * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
            foreach (CarComponent Slot in vehicle.Rear.WeaponSlots)
            {
                int xPosition = (Slot.Xpos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                int yPosition = (Slot.Ypos) * (SquareSize + SquareSize / SquareSpacing) + SquareSize / SectorSpacing;
                InitializeVisualComponent(Slot, Slot.Width, WIDTH, xOffset + xPosition, yOffset + yPosition, g);
            }
        }

        private void InitializeVisualComponent(VisualComponent component, int targetLength, int targetDirection, int xOffset, int yOffset, Graphics g)
        {
            if (targetDirection == WIDTH)
                xOffset += (targetLength - component.Width) * (SquareSize + SquareSize / SquareSpacing) / 2;
            else
                yOffset += (targetLength - component.Height) * (SquareSize + SquareSize / SquareSpacing) / 2;
            g.DrawRectangle(new Pen(Color.DarkCyan, 2), new Rectangle(xOffset - (SquareSize / SquareSpacing), yOffset - (SquareSize / SquareSpacing), component.Width * (SquareSize + (SquareSize / SquareSpacing)) + (SquareSize / SquareSpacing), component.Height * (SquareSize + SquareSize / SquareSpacing) + (SquareSize / SquareSpacing)));
            for (int x = 0; x < component.Width; x++)
            {
                for (int y = 0; y < component.Height; y++)
                {
                    SolidBrush Brush = component.SectionDamaged(x, y) ? new SolidBrush(Color.IndianRed) : new SolidBrush(Color.White);

                    g.FillRectangle(Brush, new Rectangle(xOffset + (x * (SquareSize + SquareSize / SquareSpacing)), yOffset + (y * (SquareSize + SquareSize / SquareSpacing)), SquareSize, SquareSize));
                }
            }
            if (component.Named)
            {
                Font subTitleFont = new Font("Arial", 12.0F);
                int TextWidth = (int)g.MeasureString(component.Name, subTitleFont).Width;
                Point location = new Point(xOffset + (component.Width * (SquareSize + SquareSize / SquareSpacing) / 2 - TextWidth / 2), yOffset + (component.Height * (SquareSize + SquareSize / SquareSpacing)));
                g.DrawString(component.Name, Font, new SolidBrush(Color.Black), location);
            }
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            VehicleBox.Refresh();
        }
    }
}