using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move
{
    [RequireComponent(typeof(MoveComponent), typeof(StatComponent))]
    public abstract class MoveAIComponent : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        private StatComponent _statComponent;

        private void Start()
        {
            Init();
        }
        
        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _moveComponent.Move(GetMoveDirection(), _statComponent.GetSpeed() * _statComponent.SpeedMultiplier * Time.deltaTime);
        }

        protected virtual void Init()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _statComponent = GetComponent<StatComponent>();
        }

        protected abstract Vector2 GetMoveDirection();
    }
}
