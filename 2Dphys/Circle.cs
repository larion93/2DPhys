using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Numerics;
using System.Security;
using System.Windows.Forms;

namespace Phys
{
    class Circle:Object
    {
        public float Radius { get; set; }
        public Circle(float x, float y, float d, float r, Pen p, Vector2 velocity)
        {
            Velocity = velocity;
            ElasticityCoef = 0.7f;
            Area = (float)Math.PI * r * r;
            Mass = d*Area;
            Density = d;
            Inv_mass = 1 / Mass;
            Coordinates = new Vector2(x,y);
            Radius = r;
            Pen = p;
        }
        public override void Draw(Graphics g)
        {
            Brush aBrush = Brushes.Black;
            Brush bBrush = Brushes.Red;
            g.DrawEllipse(Pen, Coordinates.X - Radius, Coordinates.Y - Radius, Radius * 2, Radius * 2);
            g.FillRectangle(aBrush, Coordinates.X, Coordinates.Y, 2, 2);
            if (ShowVector)
            {
                Pen vectorPen = new Pen(Color.Green, 4);
                Point center = new Point((int)Coordinates.X, (int)Coordinates.Y);
                Point vectorDirection = new Point((int)(Coordinates.X + Velocity.X), (int)(Coordinates.Y + Velocity.Y));
                g.DrawLine(vectorPen, center, vectorDirection);
            }
        }
    }
}
