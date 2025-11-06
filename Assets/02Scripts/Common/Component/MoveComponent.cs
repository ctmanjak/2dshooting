using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent))]
    public class MoveComponent : MonoBehaviour
    {
        private StatComponent _statComponent;

        private Vector2 _moveDirection;

        private float _knockbackTime = 0.2f;
        private float _knockbackStartTime;
        private Vector2 _knockbackDestination;

        private void Start()
        {
            _statComponent ??= GetComponent<StatComponent>();
        }

        private void Update()
        {
            if (KnockbackInternal()) return;
            
            float speed = _statComponent.Speed;
            
            Vector2 position = transform.position;
            Vector2 newPosition = position + _moveDirection * (speed * Time.deltaTime);
            transform.position = newPosition;
        }

        public void SetMoveDirection(Vector2 moveDirection)
        {
            _moveDirection = moveDirection;
        }
        
        public void Knockback(Vector2 direction, float knockbackPower)
        {
            _knockbackStartTime = Time.time;
            _knockbackDestination = (Vector2)transform.position + direction * knockbackPower;
        }

        private bool KnockbackInternal()
        {
            float elapsed = Time.time - _knockbackStartTime;
            if (elapsed > _knockbackTime) return false;
            
            transform.position = Vector2.Lerp(transform.position, _knockbackDestination, elapsed / _knockbackTime * Time.deltaTime);
            return true;
        }
    }
}
