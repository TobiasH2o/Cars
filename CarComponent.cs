using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class CarComponent : VisualComponent
    {
        public int Xpos { get; private set; }
        public int Ypos { get; private set; }

        public CarComponent(int Width, int Height, int Xpos, int Ypos, string name) : base(Width, Height, name)
        {
            this.Xpos = Xpos;
            this.Ypos = Ypos;
        }
    }
}