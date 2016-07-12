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
        public float radius;
        public Circle(float x, float y, float d, float r, Pen p, Vector2 velocity)
        {
            this.velocity.X = velocity.X;
            this.velocity.Y = velocity.Y;
            area = (float)Math.PI * r * r;
            mass = d*area;
            density = d;
            inv_mass = 1 / mass;
            coordinates.X = x;
            coordinates.Y = y;
            radius = r;
            pen = p;
        }
        public override void Draw(PaintEventArgs e)
        {
            Brush aBrush = Brushes.Black;
            Brush bBrush = Brushes.Red;
            e.Graphics.DrawEllipse(pen, coordinates.X - radius, coordinates.Y - radius, radius * 2, radius * 2);
            e.Graphics.FillRectangle(aBrush, coordinates.X, coordinates.Y, 2, 2);
            if (showVector)
            {
                Pen vectorPen = new Pen(Color.Green, 4);
                Point center = new Point((int)coordinates.X, (int)coordinates.Y);
                Point vectorDirection = new Point((int)(coordinates.X + velocity.X), (int)(coordinates.Y + velocity.Y));
                e.Graphics.DrawLine(vectorPen, center, vectorDirection);
            }
        }
    }
}
