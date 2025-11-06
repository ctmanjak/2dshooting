using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Bullet
{
    public abstract class BaseBullet : MonoBehaviour
    {
        protected float MoveSpeed = 1.0f;

        private int _extraDamage;

        protected string[] EnemyTags = { "Enemy" };
    
        [Header("스탯")]
        public int BaseDamage;
        public float MinMoveSpeed = 1.0f;
        public float MaxMoveSpeed = 7.0f;
        public float MinToMaxSeconds = 1.2f;
        
        void FixedUpdate()
        {
            Accelerate();
            Move();
        }

        public virtual void Init(int damage = 0, Vector3? position = null, Quaternion? rotation = null)
        {
            MoveSpeed = MinMoveSpeed;

            _extraDamage = damage;

            transform.position = position ?? transform.position;
            transform.rotation = rotation ?? transform.rotation;
        }

        protected virtual void Move()
        {
            Vector2 position = transform.position;
            Vector2 direction = transform.up;
            Vector2 newPosition = position + direction * (MoveSpeed * Time.deltaTime);

            transform.position = newPosition;
        }

        private void Accelerate()
        {
            if (MoveSpeed >= MaxMoveSpeed) return;
            
            MoveSpeed = Mathf.Min(MaxMoveSpeed, MoveSpeed + (MaxMoveSpeed - MinMoveSpeed) / MinToMaxSeconds * Time.deltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;
            
            bool result = otherHitbox.Hit(transform.position, BaseDamage + _extraDamage, EnemyTags);
            if (result) Destroy(gameObject);
        }
    }
}
