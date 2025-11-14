using _02Scripts.Common.Component.AI.Move;
using UnityEngine;

namespace _02Scripts.Bullet
{
    [RequireComponent(typeof(BezierMoveAIComponent))]
    public class KaisaBullet : BaseBullet
    {
        public float CurveSpeedMultiplier = 2f;
        public float DestroyRadius = 0.5f;
        public int CurveSegments = 20;

        private BezierMoveAIComponent _bezierMoveAI;

        public void InitPoint(Vector2 firstPoint, Vector2 midpoint, Vector2? lastPoint = null, int? segments = null)
        {
            Vector2 destination = lastPoint ?? new Vector2(0, 10);
            _bezierMoveAI.CurveSpeedMultiplier = CurveSpeedMultiplier;
            _bezierMoveAI.Segments = segments ?? CurveSegments;
            _bezierMoveAI.ConfigureCurve(firstPoint, midpoint, destination, _bezierMoveAI.Segments);
        }

        protected override void Awake()
        {
            _bezierMoveAI = GetComponent<BezierMoveAIComponent>();
            if (_bezierMoveAI != null)
            {
                _bezierMoveAI.UseTarget = false;
                _bezierMoveAI.AngleOffset = -90f;
            }

            base.Awake();
        }

        protected override void AfterMove()
        {
            if (_bezierMoveAI && _bezierMoveAI.HasReachedDestination(DestroyRadius))
            {
                DestroySelf();
            }
        }
    }
}
