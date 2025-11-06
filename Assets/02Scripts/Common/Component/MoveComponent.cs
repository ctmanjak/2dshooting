using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent))]
    public class MoveComponent : MonoBehaviour
    {
        private StatComponent _statComponent;

        private Vector2 _moveDirection;

        private void Start()
        {
            _statComponent ??= GetComponent<StatComponent>();
        }

        private void Update()
        {
            float speed = _statComponent.Speed;
            
            Vector2 position = transform.position;
            Vector2 newPosition = position + _moveDirection * (speed * Time.deltaTime);
            transform.position = newPosition;
        }

        public void SetMoveDirection(Vector2 moveDirection)
        {
            _moveDirection = moveDirection;
        }
    }
}
