using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class MoveComponent : MonoBehaviour
    {
        private float _speed;
        private float _speedMultiplier;
        
        public Vector2 LastMoveDirection { get; private set; }

        public virtual void Move(Vector2 direction, float speed)
        {
            Vector2 position = transform.position;
            Vector2 newPosition = position + direction * speed;
            LastMoveDirection = (newPosition - position).normalized;
            transform.position = newPosition;
        }
    }
}
