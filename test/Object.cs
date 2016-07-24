using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
namespace Phys
{
    abstract class Object
    {
        public static List<Object> objectsList = new List<Object>();
        public float Mass { get; set; }
        public float Density { get; set; }
        public float Area { get; set; }
        public Pen Pen { get; set; }
        public float Inv_mass { get; set; }
        public float ElasticityCoef { get; set; }
        public static bool ShowVector { get; set; }
        public Vector2 Velocity { get; set; }

        public Vector2 Coordinates { get; set; }
        public abstract void Draw(Graphics g);
    }
}
