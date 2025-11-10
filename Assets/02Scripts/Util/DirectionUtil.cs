using UnityEngine;

namespace _02Scripts.Util
{
    public class DirectionUtil
    {
        public static readonly Vector2[] EightDirections =
        {
            new Vector2(0, 1),
            new Vector2(1, 1).normalized,
            new Vector2(1, 0),
            new Vector2(1, -1).normalized,
            new Vector2(0, -1),
            new Vector2(-1, -1).normalized,
            new Vector2(-1, 0),
            new Vector2(-1, 1).normalized
        };
        
        public static Vector2 SnapTo8Direction(Vector2 dir)
        {
            if (dir == Vector2.zero) return Vector2.zero;

            float maxDot = -Mathf.Infinity;
            Vector2 snapped = Vector2.zero;

            foreach (var d in EightDirections)
            {
                float dot = Vector2.Dot(dir, d);
                if (dot > maxDot)
                {
                    maxDot = dot;
                    snapped = d;
                }
            }

            return snapped.normalized;
        }
    }
}