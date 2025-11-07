using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    public class SnakeMoveAIComponent : MoveAIComponent
    {
        public float Frequency = 2f;
        public float TurnAngle = 40f;

        private float _elapsedTime;

        protected override void BeforeMove()
        {
            base.BeforeMove();
            _elapsedTime += Time.deltaTime;

            float angle = TurnAngle * Mathf.Sin(_elapsedTime * Mathf.PI * 2f * Frequency);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }

        protected override Vector2 GetMoveDirection()
        {
            return transform.up;
        }
    }
}
