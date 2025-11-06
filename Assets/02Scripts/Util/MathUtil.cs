using Unity.Mathematics.Geometry;
using UnityEngine;

namespace _02Scripts.Util
{
    public static class MathUtil
    {
        public static Vector2 QuadraticLerp(Vector2 p0, Vector2 p1, Vector2 p2, float t)
        {
            t = Mathf.Clamp01(t);
            
            // 1단계: p0 ~ p1 사이 중간점
            Vector2 a = Vector2.Lerp(p0, p1, t);

            // 2단계: p1 ~ p2 사이 중간점
            Vector2 b = Vector2.Lerp(p1, p2, t);

            // 3단계: a ~ b 사이 중간점 → 이게 베지에 곡선 위의 점
            Vector2 point = Vector2.Lerp(a, b, t);

            return point;
        }
        
        public static float GetQuadraticBezierLength(Vector2 p0, Vector2 p1, Vector2 p2, int segments = 20)
        {
            float length = 0f;
            Vector2 prev = p0;

            for (int i = 1; i <= segments; i++)
            {
                float t = (float)i / segments;
                Vector2 point = QuadraticLerp(p0, p1, p2, t);
                length += Vector2.Distance(prev, point);
                prev = point;
            }

            return length;
        }

        public static Quaternion DirectionToQuaternion(Vector2 direction, float angleOffset)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
            return Quaternion.Euler(0f, 0f, angle);
        }
    }
}