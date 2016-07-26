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
    class LineSegment:Line
    {
        public LineSegment(Tuple<Vector2, Vector2> border):base(border)
        {
        }
    }
}
