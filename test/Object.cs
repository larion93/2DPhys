﻿using System;
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
        public Vector2 velocity;
        public Vector2 coordinates;
        public float mass;
        public float density;
        public float area;
        public Pen pen;
        public float inv_mass;
        public static bool showVector;
        public static List<Object> objectsList = new List<Object>();
        public abstract void Draw(PaintEventArgs e);
    }
}
