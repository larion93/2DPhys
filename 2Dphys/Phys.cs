using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

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
                if (gravityOn) obj.Velocity += gravity * dt;
                obj.Coordinates += obj.Velocity * dt;
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
                float massTotal = obj1.Inv_mass + obj2.Inv_mass;
                Vector2 correction = (max / massTotal) * percent * normal;
                obj1.Coordinates += obj1.Inv_mass * correction;
                obj2.Coordinates -= obj2.Inv_mass * correction;
            }
        }
        private static void CheckAndResolveCollision(Pair pair)
        {
            dynamic obj1 = pair.pair.Item1;
            dynamic obj2 = pair.pair.Item2;
            Vector2 normal = pair.Normal;
            float distance = pair.Distance;
            float relVelocity = Vector2.Dot(obj1.Velocity, normal);
            float remove = relVelocity + distance / dt;
            if (remove < 0)
            {
                ResolveCollision(obj1, obj2, normal);
                PositionalCorrection(obj1, obj2, normal, distance);
            }
        }
        private static void ResolveCollision(Circle obj1, Circle obj2, Vector2 normal)
        {
            Vector2 rv = obj1.Velocity - obj2.Velocity;
            float elasticityCoef = Math.Min(obj1.ElasticityCoef, obj2.ElasticityCoef);
            float velAlongNormal = Vector2.Dot(rv, normal);
            float j = -(1 + elasticityCoef) * velAlongNormal;
            float mass_sum = obj1.Mass + obj2.Mass;
            j /= obj1.Inv_mass + obj2.Inv_mass;
            Vector2 impulse = j * normal;
            obj1.Velocity += obj1.Inv_mass * impulse;
            obj2.Velocity -= obj2.Inv_mass * impulse;
        }
        private static void ResolveCollision(Circle obj1, Line obj2, Vector2 normal)
        {
            //obj1.velocity *= 0.5f;
            Vector2 projection = obj1.Velocity.Length() * normal;
            Render.DrawVector(projection);
            Vector2 slide = obj1.Velocity + projection;
            float relVelocity = Vector2.Dot(obj1.Velocity, normal);
            //Vector2 relVelocityVector = obj1.velocity - projection;
            //float relVelocity = relVelocityVector.Length();
            //obj1.velocity += slide;
            //if (Math.Abs(relVelocity) < 1)
            //{
                obj1.Velocity += slide;
            //Render.DrawVector(slide);
            //}
            //else
            //{
                obj1.Velocity *= Math.Min(obj1.ElasticityCoef, obj2.ElasticityCoef);
                obj1.Velocity = Vector2.Reflect(obj1.Velocity, normal);
            //}
            //obj1.velocity = Vector2.Reflect(obj1.velocity, normal);
        }
    }
}
