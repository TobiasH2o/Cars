using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class MapComponent : VisualComponent
    {

        public int Xpos { get; private set; }
        public int Ypos { get; private set; }
        private int Traversable;
        public MapComponent(int Xpos, int Ypos, int Width, int Height, int? Traversable = null) : base(Width, Height, "")
        {
            this.Xpos = Xpos;
            this.Ypos = Ypos;
            this.Traversable = Traversable ?? -1;
        }

        public bool IsTraversable(int VehicleType)
        {
            return VehicleType <= Traversable;
        }
    }
}
