using System;
using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class MoveComponent : MonoBehaviour
    {
        private float _speed;
        private float _speedMultiplier;
        
        public Vector2 LastMoveDirection { get; private set; }

        public event Action AfterMove;

        public virtual void Move(Vector2 direction, float speed)
        {
            Vector2 position = transform.position;
            Vector2 newPosition = position + direction * speed;
            LastMoveDirection = (newPosition - position).normalized;
            transform.position = newPosition;
            
            AfterMove?.Invoke();
        }

        public void Rotate(Quaternion rotation)
        {
            transform.rotation = rotation;
        }

        public void SetAfterMove(Action action)
        {
            AfterMove += action;
        }
    }
}
