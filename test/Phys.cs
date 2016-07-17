using System;
using System.Collections.Generic;
using System.Numerics;

namespace Phys
{
    static class Physics
    {
        public static List<Plane> borders = new List<Plane>();
        static Vector2 gravity = new Vector2(0, 98.0f);
        static List<Tuple<Circle,Circle>> checkedPairs = new List<Tuple<Circle, Circle>>();
        public static float dt;
        public static bool gravityOn = true;
        public static void ComputePhysics()
        {
            foreach (Pair pair in Pair.uniquePairs)
            {
                CheckAndResolveCollision(pair);
            }
            foreach (Object obj in Object.objectsList)
            {
                if (gravityOn) obj.velocity += gravity * dt;
                obj.coordinates += obj.velocity * dt;
            }
        }
        static void PositionalCorrection(Object obj1, Object obj2, Vector2 normal, float penetration)
        {
            const float percent = 0.8f;
            const float slop = 0.01f;
            if(penetration<0)
            {
                penetration = Math.Abs(penetration);
                float max = Math.Max(penetration - slop, 0.0f);
                float massTotal = obj1.inv_mass + obj2.inv_mass;
                Vector2 correction = (max / massTotal) * percent * normal;
                obj1.coordinates += obj1.inv_mass * correction;
                obj2.coordinates -= obj2.inv_mass * correction;
            }
        }
        private static void CheckAndResolveCollision(Pair pair)
        {
            dynamic obj1 = pair.pair.Item1;
            dynamic obj2 = pair.pair.Item2;
            Vector2 normal = pair.Normal;
            float distance = pair.Distance;
            float relVelocity = Vector2.Dot(obj1.velocity, normal);
            float remove = relVelocity + distance / dt;
            if (remove < 0)
            {
                ResolveCollision(obj1, obj2, normal);
                PositionalCorrection(obj1, obj2, normal, distance);
            }
        }
        private static void ResolveCollision(Circle obj1, Circle obj2, Vector2 normal)
        {
            Vector2 rv = obj1.velocity - obj2.velocity;
            float velAlongNormal = Vector2.Dot(rv, normal);
            float j = -(1 + 0.7f) * velAlongNormal;
            float mass_sum = obj1.mass + obj2.mass;
            j /= obj1.inv_mass + obj2.inv_mass;
            Vector2 impulse = j * normal;
            obj1.velocity += obj1.inv_mass * impulse;
            obj2.velocity -= obj2.inv_mass * impulse;
        }
        private static void ResolveCollision(Circle obj1, Line obj2, Vector2 normal)
        {
            obj1.velocity *= 0.5f;
            obj1.velocity = Vector2.Reflect(obj1.velocity, normal);
        }
    }
}
