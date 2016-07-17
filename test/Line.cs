using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Numerics;

namespace Phys
{
    class Line:Object
    {
        public Tuple<Vector2, Vector2> line;
        public Tuple<Point, Point> linePoint;
        public Vector2 normalLeft;
        public Vector2 normalRight;
        public Line(Tuple<Vector2, Vector2> border)
        {
            inv_mass = 0;
            line = border;
            normalLeft = Vector2.Normalize(new Vector2 ((line.Item2.Y - line.Item1.Y),-(line.Item2.X - line.Item1.X)));
            normalRight = Vector2.Normalize(new Vector2(-(line.Item2.Y - line.Item1.Y), (line.Item2.X - line.Item1.X)));
            Point point1 = new Point((int)line.Item1.X, (int)line.Item1.Y);
            Point point2 = new Point((int)line.Item2.X, (int)line.Item2.Y);
            linePoint = new Tuple<Point, Point>(point1, point2);
        }
        public override void Draw(PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 4);
            e.Graphics.DrawLine(pen, linePoint.Item1, linePoint.Item2);
        }
    }
}
