using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    [RequireComponent(typeof(MoveComponent))]
    public abstract class AIComponent : MonoBehaviour
    {
        private MoveComponent _moveComponent;

        private Vector2 _previousMoveDirection;

        private void Start()
        {
            Init();
        }
        
        private void Update()
        {
            Vector2 newMoveDirection = GetMoveDirection();
            if (newMoveDirection != _previousMoveDirection)
            {
                _moveComponent.SetMoveDirection(newMoveDirection);
            }
        }

        protected virtual void Init()
        {
            _moveComponent = GetComponent<MoveComponent>();
        }

        protected abstract Vector2 GetMoveDirection();
    }
}
