using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    public class BezierMoveAIComponent : TargetMoveAIComponent
    {
        public float CurveSpeedMultiplier = 2f;
        public float MidpointPosition = 5f;
        public float LastPointOverDistance = 5f;
        public float AngleOffset = -90f;
        public bool UseTarget = true;
        public int Segments = 20;

        private readonly BezierCurveTracker _curveTracker = new();
        private bool _curveInitialized;

        public void ConfigureCurve(Vector2 firstPoint, Vector2 midpoint, Vector2 lastPoint, int? segments = null, bool resetProgress = true)
        {
            int segmentCount = segments ?? Segments;
            _curveTracker.Configure(firstPoint, midpoint, lastPoint, segmentCount, resetProgress);
            _curveInitialized = true;
        }

        public void InitPoint(Vector2 firstPoint, Vector2? lastPoint = null, int? segments = null)
        {
            Vector2 destination = lastPoint ?? new Vector2(0, 10);
            Vector2 midpoint = GetMidpoint(firstPoint, destination, MidpointPosition, MidpointPosition);

            ConfigureCurve(firstPoint, midpoint, destination, segments);
        }

        protected override void Init()
        {
            base.Init();
            if (!UseTarget) return;
            if (!IsTargetExist()) return;
            InitPoint(
                transform.position,
                GetTargetPosition() + GetTargetDirection() * LastPointOverDistance,
                Segments
            );
        }

        protected override void BeforeMove()
        {
            if (!UseTarget) return;
            if (!IsTargetExist() || !_curveInitialized) return;
            Vector2 destination = GetTargetPosition() + GetTargetDirection() * LastPointOverDistance;
            Vector2 midpoint = GetMidpoint(transform.position, destination, MidpointPosition, MidpointPosition);

            ConfigureCurve(transform.position, midpoint, destination, Segments, resetProgress: false);
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
            if (!_curveInitialized) return Vector2.zero;

            float progress = _curveTracker.Advance(Time.deltaTime, MoveStatComponent.GetSpeed(), CurveSpeedMultiplier);
            Vector2 destination = _curveTracker.Evaluate(progress);
            Vector2 direction = destination - (Vector2)transform.position;

            if (direction != Vector2.zero)
            {
                transform.rotation = MathUtil.DirectionToQuaternion(direction, AngleOffset);
            }

            if (direction == Vector2.zero)
            {
                return UseTarget ? GetTargetDirection() : Vector2.zero;
            }

            return direction;
        }

        public bool HasReachedDestination(float radius)
        {
            return _curveInitialized && _curveTracker.IsArrived(transform.position, radius);
        }
    }
}
