using UnityEngine;

namespace _02Scripts.Util
{
    /// <summary>
    /// 베지어 곡선 제어점과 진행률을 추적하며 보간을 도와주는 헬퍼.
    /// MonoBehaviour에 의존하지 않고 필요한 스크립트에서 직접 내장해 사용한다.
    /// </summary>
    public class BezierCurveTracker
    {
        private float _totalLength = 1f;
        private int _segments = 20;

        public Vector2 FirstPoint { get; private set; }
        private Vector2 Midpoint { get; set; }
        private Vector2 LastPoint { get; set; }

        private float Progress { get; set; }

        public void Configure(Vector2 firstPoint, Vector2 midpoint, Vector2 lastPoint, int segments = 20, bool resetProgress = true)
        {
            FirstPoint = firstPoint;
            Midpoint = midpoint;
            LastPoint = lastPoint;
            _segments = Mathf.Max(1, segments);
            RecalculateLength();

            if (resetProgress)
            {
                Progress = 0f;
            }
        }

        public void UpdateLastPoint(Vector2 lastPoint, bool recalcLength)
        {
            LastPoint = lastPoint;
            if (recalcLength)
            {
                RecalculateLength();
            }
        }

        public void UpdateMidpoint(Vector2 midpoint, bool recalcLength)
        {
            Midpoint = midpoint;
            if (recalcLength)
            {
                RecalculateLength();
            }
        }

        public float Advance(float deltaTime, float speed, float curveSpeedMultiplier)
        {
            if (_totalLength <= 0f)
            {
                return Progress;
            }

            float scaledSpeed = speed * Mathf.Max(0f, curveSpeedMultiplier);
            if (scaledSpeed <= 0f)
            {
                return Progress;
            }

            Progress += deltaTime * scaledSpeed / _totalLength;
            Progress = Mathf.Clamp01(Progress);
            return Progress;
        }

        public Vector2 Evaluate(float progress)
        {
            return MathUtil.QuadraticLerp(FirstPoint, Midpoint, LastPoint, Mathf.Clamp01(progress));
        }

        public bool IsArrived(Vector2 currentPosition, float radius)
        {
            return Vector2.Distance(currentPosition, LastPoint) <= radius;
        }

        private void RecalculateLength()
        {
            _totalLength = Mathf.Max(0.0001f, MathUtil.GetQuadraticBezierLength(FirstPoint, Midpoint, LastPoint, _segments));
        }
    }
}
