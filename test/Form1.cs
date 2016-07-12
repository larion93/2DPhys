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
        int height;
        int width;
        public Form1()
        {
            InitializeComponent();
            height = panel1.Height;
            width = panel1.Width;
            Physics.dt = (float)timer.Interval / 1000;
            Object.objectsList.Add(new Border(new Vector3(1, 0, 0), 0));
            Object.objectsList.Add(new Border(new Vector3(0, -1, 0), height));
            Object.objectsList.Add(new Border(new Vector3(-1, 0, 0), width));
            Object.objectsList.Add(new Border(new Vector3(0, 1, 0), 0)); 
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
                //velocity.X = 50;
                //velocity.Y = 50;
                velocity.Y = rnd.Next(-100, 100);
            }
            Pen pen = new Pen(Color.Blue, 4);
            //float radius = rnd.Next(20,50);
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
