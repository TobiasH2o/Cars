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
    public partial class Map : Form
    {
        int BoardWidth = 25;
        int BoardHeight = 15;
        int Buffer = 20;
        int DotSize = 2;
        int Xoffset;
        int Yoffset;
        int BoxSize = 10;
        int DashCount = 3;
        int PointSize = 6;
        float[] DashSizes;
        public Map()
        {
            InitializeComponent();
            CalculateBoardSize();
        }

        private void CalculateBoardSize()
        {
            int Height = MapBox.Height - Buffer;
            int Width = MapBox.Width - Buffer;
            BoxSize = Math.Min(Height / BoardHeight, Width / BoardWidth);
            Xoffset = Buffer + (Width - (BoardWidth * BoxSize)) / 2;
            Yoffset = Buffer + (Height - (BoardHeight * BoxSize)) / 2;
            int DashLength = (BoxSize - DotSize) / (2*DashCount);
            DashSizes = new float[]{DashLength, DashLength};
        }


        private void MapBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 1);
            pen.DashPattern = DashSizes;
            for(int y = 0; y < BoardHeight; y++)
            {
                g.DrawLine(pen, new Point(Xoffset, Yoffset + y * BoxSize), new Point(Xoffset + (BoardWidth-1) * BoxSize, Yoffset + y * BoxSize));
            }
            for(int x = 0; x < BoardWidth; x++)
            {
                g.DrawLine(pen, new Point(Xoffset + x * BoxSize, Yoffset), new Point(Xoffset + x * BoxSize, Yoffset + (BoardHeight-1) * BoxSize));
            }
            for(int x = 0; x < BoardWidth; x++)
            {
                for(int y = 0; y < BoardHeight; y++)
                {
                    Rectangle Point = new Rectangle((Xoffset + x * BoxSize) - PointSize / 2, (Yoffset + y * BoxSize) - PointSize / 2, PointSize, PointSize);
                    g.FillEllipse(new SolidBrush(Color.Black),Point);
                }
            }
        }


    }
}
