using System.Collections.Generic;
using _02Scripts.Common.Component.Stat;
using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    public class PetMoveAIComponent : TargetMoveAIComponent
    {
        private MoveComponent _targetMoveComponent;
        private MoveStatComponent _targetMoveStatComponent;
        private readonly Queue<Vector2> _targetPositionQueue = new ();

        public int DelayStep = 10;
        public float SampleMinDistance = 0.05f;

        private Vector2 _lastSampledPosition;
        private Vector2 _delayedTargetPosition;
        private Vector2 _lastMoveDirection;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void Init()
        {
            base.Init();
            
            _targetMoveComponent = GetTargetComponent<MoveComponent>();
            _targetMoveStatComponent = GetTargetComponent<MoveStatComponent>();
            
            _lastSampledPosition = GetTargetPosition();
            for (int i = 0; i < DelayStep; i++)
            {
                _targetPositionQueue.Enqueue(_lastSampledPosition);
            }
            _delayedTargetPosition = _lastSampledPosition;
        }

        protected override void BeforeMove()
        {
            if (_targetMoveStatComponent) MoveStatComponent.SetSpeed(_targetMoveStatComponent.GetSpeed());
            
            Vector2 targetPosition = GetTargetPosition();

            Vector2 targetLastMoveDirection = _targetMoveComponent.LastMoveDirection;
            if (_lastMoveDirection == targetLastMoveDirection
                && (targetPosition - _lastSampledPosition).sqrMagnitude < SampleMinDistance * SampleMinDistance)
                return;

            _lastMoveDirection = targetLastMoveDirection;
            _lastSampledPosition = targetPosition;
            _targetPositionQueue.Enqueue(targetPosition);
        }

        protected override Vector2 GetMoveDirection()
        {
            if (_targetPositionQueue.Count <= DelayStep)
                return Vector2.zero;

            while (_targetPositionQueue.Count > DelayStep)
            {
                _delayedTargetPosition = _targetPositionQueue.Dequeue();
            }

            Vector2 toDestination = _delayedTargetPosition - (Vector2)transform.position;
            if (toDestination == Vector2.zero)
                return Vector2.zero;

            Vector2 direction = DirectionUtil.SnapTo8Direction(toDestination.normalized);

            return direction;
        }
    }
}
