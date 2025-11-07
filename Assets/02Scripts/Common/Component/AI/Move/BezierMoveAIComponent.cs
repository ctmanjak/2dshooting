using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    public class BezierMoveAIComponent : TargetMoveAIComponent
    {
        private float _totalLength;
        public float CurveSpeedMultiplier = 2f;
        public float MidpointPosition = 5f;
        public float LastPointOverDistance = 5f;

        private Vector2 FirstPoint { get; set; }
        private Vector2 Midpoint { get; set; }
        private Vector2 LastPoint { get; set; }

        private float _elapsedTime;
        
        public void InitPoint(Vector2 firstPoint, Vector2? lastPoint = null, int segments = 20)
        {
            FirstPoint = firstPoint;
            Midpoint = GetMidpoint(FirstPoint, LastPoint, MidpointPosition, MidpointPosition);
            LastPoint = lastPoint ?? new Vector2(0, 10);
            
            _totalLength = MathUtil.GetQuadraticBezierLength(FirstPoint, Midpoint, LastPoint, segments);
        }
        
        protected override void Init()
        {
            base.Init();

            if (!IsTargetExist()) return;
            InitPoint(
                transform.position,
                GetTargetPosition() + GetTargetDirection() * LastPointOverDistance
            );
        }

        protected override void BeforeMove()
        {
            if (!IsTargetExist()) return;
            LastPoint = GetTargetPosition() + GetTargetDirection() * LastPointOverDistance;
        }
        
        private Vector2 GetMidpoint(Vector2 firstPoint, Vector2 lastPoint, float back, float side)
        {
            Vector2 direction = (lastPoint - firstPoint).normalized;
            Vector2 normal = new Vector2(-direction.y, direction.x);
            
            float sideSign = -Mathf.Sign(lastPoint.x - firstPoint.x);
            if (sideSign == 0) sideSign = 1f;
            
            return firstPoint
                - direction * back
                + normal * (sideSign * side);
        }

        protected override Vector2 GetMoveDirection()
        {
            _elapsedTime += Time.deltaTime * (MoveStatComponent.GetSpeed() * CurveSpeedMultiplier) / _totalLength;

            Vector2 destination = MathUtil.QuadraticLerp(FirstPoint, Midpoint, LastPoint, _elapsedTime);
            Vector3 direction = destination - (Vector2)transform.position;
            
            return direction;
        }
    }
}
