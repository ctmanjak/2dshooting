using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Bullet
{
    public class KaisaBullet : BaseBullet
    {
        private float _totalLength;
        public float CurveSpeedMultiplier = 2f;
        public float DestroyRadius = 0.5f;

        private Vector2 FirstPoint { get; set; }
        private Vector2 Midpoint { get; set; }
        private Vector2 LastPoint { get; set; }

        private float _elapsedTime;

        public void InitPoint(Vector2 firstPoint, Vector2 midpoint, Vector2? lastPoint = null, int segments = 20)
        {
            FirstPoint = firstPoint;
            Midpoint = midpoint;
            LastPoint = lastPoint ?? new Vector2(0, 10);
            
            _totalLength = MathUtil.GetQuadraticBezierLength(FirstPoint, Midpoint, LastPoint, segments);
        }
        
        protected override void Move()
        {
            _elapsedTime += Time.deltaTime * (MoveSpeed * CurveSpeedMultiplier) / _totalLength;

            Vector2 destination = MathUtil.QuadraticLerp(FirstPoint, Midpoint, LastPoint, _elapsedTime);
            Vector3 direction = destination - (Vector2)transform.position;
            transform.rotation = MathUtil.DirectionToQuaternion(direction, -90f);
            
            base.Move();

            if (Vector2.Distance(transform.position, LastPoint) <= DestroyRadius)
            {
                Destroy(gameObject);
            }
        }
    }
}