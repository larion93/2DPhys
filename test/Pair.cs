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
            return Vector2.Normalize(obj1.Coordinates - obj2.Coordinates);
        }
        private Vector2 GetNormalVector(Circle obj1, Line obj2)
        {
            Vector2 point1 = obj2.LineVectors.Item1;
            Vector2 point2 = obj2.LineVectors.Item2;
            Vector2 circleCenter = obj1.Coordinates;
            float value = (point2.X - point1.X) * (circleCenter.Y - point1.Y) - (circleCenter.X - point1.X) * (point2.Y - point1.Y);
            if (value < 0) { return obj2.NormalLeft; }
            else if (value > 0) { return obj2.NormalRight; }
            return obj2.NormalLeft;
        }
        public float GetDistance(Circle obj1, Line obj2)
        {
            Vector2 point1 = obj2.LineVectors.Item1;
            Vector2 point2 = obj2.LineVectors.Item2;
            Vector2 ab = point2 - point1;
            Vector2 ap = obj1.Coordinates - point1;
            Vector2 projection = point1 + Vector2.Dot(ap, ab) / Vector2.Dot(ab, ab) * ab;
            float distance = Vector2.Distance(obj1.Coordinates, projection) - obj1.Radius;
            return distance;
        }
        public float GetDistance(Circle obj1, LineSegment obj2)
        {
            Vector2 point1 = obj2.LineVectors.Item1;
            Vector2 point2 = obj2.LineVectors.Item2;
            Vector2 ab = point2 - point1;
            Vector2 ap = obj1.Coordinates - point1;
            float lineLength = ab.LengthSquared();
            var t = Vector2.Dot(ab, ap) / lineLength;
            if (t < 0) { t = 0; }
            if (t > 1) { t = 1; }
            var nearest = point1 + t * ab;
            float distance = Vector2.Distance(nearest, obj1.Coordinates) - obj1.Radius;
            return distance;
        }
        public float GetDistance(Circle obj1, Circle obj2)
        {
            return Vector2.Distance(obj1.Coordinates, obj2.Coordinates) - obj1.Radius - obj2.Radius;
        }
    }
}
