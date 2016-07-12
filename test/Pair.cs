using System;
using System.Collections.Generic;
using System.Numerics;

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
        private Vector2 GetNormalVector(Circle obj1, Border obj2)
        {
            return new Vector2(obj2.plane.Normal.X, obj2.plane.Normal.Y);
        }
        public float GetDistance(Circle obj1, Border obj2)
        {
            return obj1.coordinates.X * obj2.plane.Normal.X + obj1.coordinates.Y * obj2.plane.Normal.Y + obj2.plane.D - obj1.radius;
        }
        public float GetDistance(Circle obj1, Circle obj2)
        {
            return Vector2.Distance(obj1.coordinates, obj2.coordinates) - obj1.radius - obj2.radius;
        }
    }
}
