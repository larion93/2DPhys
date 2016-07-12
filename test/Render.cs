using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Numerics;

namespace Phys
{

    static class Render
    {
        static public bool showVector = false;
        //static public HashSet<Tuple<Circle, Circle>> uniquePairs = new HashSet<Tuple<Circle, Circle>>(); 
        static public void RenderAll(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Object obj in Object.objectsList)
            {
                obj.Draw(e);
            }
        }
    }
}
