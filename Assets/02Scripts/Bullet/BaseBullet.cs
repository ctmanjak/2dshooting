using _02Scripts.Enemy;
using UnityEngine;

namespace _02Scripts.Bullet
{
    public abstract class BaseBullet : MonoBehaviour
    {
        private float _moveSpeed = 1.0f;

        private int _extraDamage;
    
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

        public void Init(int damage = 0, Vector3? position = null, Quaternion? rotation = null)
        {
            _moveSpeed = MinMoveSpeed;

            _extraDamage = damage;

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
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            HealthComponent otherHealth = other.GetComponentInParent<HealthComponent>();
            if (!otherHealth) return;
            
            if (!otherHealth.CompareTag("Enemy")) return;
            
            Destroy(gameObject);

            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            float damageMultiplier = otherHitbox?.DamageMultiplier ?? 1.0f; 
            
            otherHealth.TakeDamage((int)((BaseDamage + _extraDamage) * damageMultiplier));
        }
    }
}
