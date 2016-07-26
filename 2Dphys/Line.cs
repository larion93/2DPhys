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
        public Tuple<Vector2, Vector2> LineVectors { get; set; }
        public Tuple<Point, Point> LinePoint { get; set; }
        public Vector2 NormalLeft { get; set; }
        public Vector2 NormalRight { get; set; }

        public Line(Tuple<Vector2, Vector2> border)
        {
            Inv_mass = 0;
            ElasticityCoef = 0.5f;
            LineVectors = border;
            NormalLeft = Vector2.Normalize(new Vector2 ((LineVectors.Item2.Y - LineVectors.Item1.Y),-(LineVectors.Item2.X - LineVectors.Item1.X)));
            NormalRight = Vector2.Normalize(new Vector2(-(LineVectors.Item2.Y - LineVectors.Item1.Y), (LineVectors.Item2.X - LineVectors.Item1.X)));
            Point point1 = new Point((int)LineVectors.Item1.X, (int)LineVectors.Item1.Y);
            Point point2 = new Point((int)LineVectors.Item2.X, (int)LineVectors.Item2.Y);
            LinePoint = new Tuple<Point, Point>(point1, point2);
        }
        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 4);
            g.DrawLine(pen, LinePoint.Item1, LinePoint.Item2);
        }
    }
}
