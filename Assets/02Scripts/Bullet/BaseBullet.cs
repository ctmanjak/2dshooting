using System;
using UnityEngine;

namespace _02Scripts.Bullet
{
    public abstract class BaseBullet : MonoBehaviour
    {
        private float _moveSpeed = 1.0f;
    
        public float MinMoveSpeed = 1.0f;
        public float MaxMoveSpeed = 7.0f;
        public float MinToMaxSeconds = 1.2f; 

        void Start()
        {
            Init();
        }
        
        void FixedUpdate()
        {
            Accelerate();
            Move();
        }

        public void Init(Vector3? position = null, Quaternion? rotation = null)
        {
            _moveSpeed = MinMoveSpeed;

            transform.position = position ?? transform.position;
            transform.rotation = rotation ?? transform.rotation;
        }

        protected virtual void Move()
        {
            Vector2 position = transform.position;
            Vector2 direction = transform.up;
            Vector2 newPosition = position + direction * (_moveSpeed * Time.deltaTime);

            transform.position = newPosition;
        }

        private void Accelerate()
        {
            _moveSpeed = Mathf.Min(MaxMoveSpeed, _moveSpeed + (MaxMoveSpeed - MinMoveSpeed) / MinToMaxSeconds * Time.deltaTime);
        }
    }
}
