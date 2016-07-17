using System;
using System.Collections.Generic;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;

namespace Phys
{
    class Pair
    {
        public static HashSet<Pair> uniquePairs = new HashSet<Pair>();
        public Tuple<dynamic, dynamic> pair;
        public Vector2 Normal
        {
            get { return GetNormalVector(pair.Item1, pair.Item2); }
        }
        public float Distance
        {
            get  {return GetDistance(pair.Item1, pair.Item2); }
        }
        public Pair(Object obj1, Object obj2)
        {
            pair = new Tuple<dynamic, dynamic>(obj1, obj2);
        }
        private Vector2 GetNormalVector(Circle obj1, Circle obj2)
        {
            return Vector2.Normalize(obj1.coordinates - obj2.coordinates);
        }
        private Vector2 GetNormalVector(Circle obj1, Line obj2)
        {
            Vector2 point1 = obj2.line.Item1;
            Vector2 point2 = obj2.line.Item2;
            Vector2 circleCenter = obj1.coordinates;
            float value = (point2.X - point1.X) * (circleCenter.Y - point1.Y) - (circleCenter.X - point1.X) * (point2.Y - point1.Y);
            if (value < 0) { return obj2.normalLeft; }
            else if (value > 0) { return obj2.normalRight; }
            return obj2.normalLeft;
        }
        public float GetDistance(Circle obj1, Line obj2)
        {
            Vector2 point1 = obj2.line.Item1;
            Vector2 point2 = obj2.line.Item2;
            Vector2 ab = point2 - point1;
            Vector2 ap = obj1.coordinates - point1;
            Vector2 projection = point1 + Vector2.Dot(ap, ab) / Vector2.Dot(ab, ab) * ab;
            float distance = Vector2.Distance(obj1.coordinates, projection) - obj1.radius;
            return distance;
        }
        public float GetDistance(Circle obj1, Circle obj2)
        {
            return Vector2.Distance(obj1.coordinates, obj2.coordinates) - obj1.radius - obj2.radius;
        }
    }
}
