using _02Scripts.Common.Component.AI.Move;
using UnityEngine;

namespace _02Scripts.Bullet
{
    [RequireComponent(typeof(SnakeMoveAIComponent))]
    public class SnakeBullet : BaseBullet
    {
        public float Frequency = 2.0f;
        public float TurnAngle = 40.0f;

        private SnakeMoveAIComponent _snakeMoveAI;

        protected override void Awake()
        {
            base.Awake();
            
            _snakeMoveAI = GetComponent<SnakeMoveAIComponent>();
            _snakeMoveAI.Frequency = Frequency;
            _snakeMoveAI.TurnAngle = TurnAngle;
        }
    }
}
