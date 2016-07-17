using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Phys
{
    public partial class Form1 : Form
    {
        public class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.UserPaint, true);
            }
        }

        float density = 10;
        static int height;
        static int width;
        public Form1()
        {
            InitializeComponent();
            height = panel1.Height;
            width = panel1.Width;
            Physics.dt = (float)timer.Interval / 1000;
            Tuple<Vector2, Vector2> border1 = new Tuple<Vector2, Vector2>(new Vector2(width, 0), new Vector2(0, 0));
            Tuple<Vector2, Vector2> border2 = new Tuple<Vector2, Vector2>(new Vector2(width, height), new Vector2(width, 0));
            Tuple<Vector2, Vector2> border3 = new Tuple<Vector2, Vector2>(new Vector2(0, height), new Vector2(width, height));
            Tuple<Vector2, Vector2> border4 = new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(0, height));
            Tuple<Vector2, Vector2> border5 = new Tuple<Vector2, Vector2>(new Vector2(0, 0), new Vector2(width, height));
            Object.objectsList.Add(new Line(border1));
            Object.objectsList.Add(new Line(border2)); 
            Object.objectsList.Add(new Line(border3)); 
            Object.objectsList.Add(new Line(border4));
            Object.objectsList.Add(new Line(border5));
            formParam.Text = height.ToString() + ", " + width.ToString();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Physics.ComputePhysics();
            circleCount.Text = Object.objectsList.Count.ToString();
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        private void switchGravity_btn_Click(object sender, EventArgs e)
        {
            Physics.gravityOn = !Physics.gravityOn;
        }
        private void showVector_btn_Click(object sender, EventArgs e)
        {
            Object.showVector = !Object.showVector;
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Vector2 velocity;
            Random rnd = new Random();
            float radius = rnd.Next(20, 50);
            if (e.Button == MouseButtons.Right)
            {
                velocity.X = 0;
                velocity.Y = 0;
            }
            else
            {
                velocity.X = rnd.Next(-100, 100);
                velocity.Y = rnd.Next(-100, 100);
            }
            Pen pen = new Pen(Color.Blue, 4);
            Circle circ = new Circle(e.X, e.Y, density, radius, pen, velocity);
            foreach (Object obj in Object.objectsList)
            {
                Pair pair = new Pair(circ, obj);
                Pair.uniquePairs.Add(pair);
            }
            Object.objectsList.Add(circ);
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Render.RenderAll(e);
        }
    }
}
