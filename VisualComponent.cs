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
        public bool Named { get; protected set; } = true;
        public string Name = "";

        public VisualComponent(int width, int height, string name) : base(width, height)
        {
            Name = name;
        }

        public new void Damage(double DamageDealt)
        {
            base.Damage(DamageDealt);
        }

        public new void Restore()
        {
            base.Restore();
            Damage(0);
        }
    }
}