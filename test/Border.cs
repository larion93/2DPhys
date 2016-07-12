using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Phys
{
    class Border:Object
    {
        //public static List<Border> borders = new List<Border>();
        public Plane plane;
        public Border(Vector3 vector,int d)
        {
            inv_mass = 0;
            this.plane = new Plane(vector,d);
        }
    }
}
