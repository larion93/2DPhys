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

    public class Render
    {
        public static Graphics g;
        public static Bitmap buffer; // buffer is used, so drawing outside Render class is possible
        static public bool showVector = false;
        //static public HashSet<Tuple<Circle, Circle>> uniquePairs = new HashSet<Tuple<Circle, Circle>>(); 
        static public void RenderAll()
        {
            g.DrawImage(buffer,0,0);
            buffer.Dispose();
            buffer = new Bitmap(Form1.width, Form1.height); // Clear buffer after drawing
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (Object obj in Object.objectsList)
            {
                obj.Draw(g);
            }
        }
        static public void DrawVector(Vector2 vector)
        {
            using (Graphics g = Graphics.FromImage(buffer))
            {
                Brush brush = Brushes.Purple;
                g.FillRectangle(brush, vector.X, vector.Y, 6, 6);
            }
        }
        static public void DrawLine(Vector2 vector1, Vector2 vector2)
        {
            using (Graphics g = Graphics.FromImage(buffer))
            {
                Pen pen = new Pen(Color.Purple, 4);
                g.DrawLine(pen, vector1.X, vector1.Y, vector2.X, vector2.Y);
            }
        }
    }
}
