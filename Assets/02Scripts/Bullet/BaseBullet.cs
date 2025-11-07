using _02Scripts.Bullet.Component;
using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Bullet
{
    [RequireComponent(typeof(MoveComponent), typeof(BulletStatComponent))]
    public abstract class BaseBullet : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        protected BulletStatComponent BulletStatComponent;

        private int _extraDamage;

        protected string[] EnemyTags = { "Enemy" };

        private void Awake()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _moveComponent.SetAfterMove(AfterMove);

            BulletStatComponent = GetComponent<BulletStatComponent>();
        }
        private void FixedUpdate()
        {
            Accelerate();
            _moveComponent.Rotate(GetRotation());
            _moveComponent.Move(transform.up, BulletStatComponent.Speed * Time.deltaTime);
        }

        public virtual void Init(int damage = 0, Quaternion? rotation = null)
        {
            BulletStatComponent.SetSpeed(BulletStatComponent.MinSpeed);
            _extraDamage = damage;

            transform.rotation = rotation ?? transform.rotation;
            transform.position = transform.position;
        }

        protected virtual Quaternion GetRotation()
        {
            return Quaternion.LookRotation(Vector3.forward, transform.up);
        }

        protected virtual void AfterMove()
        {
        }

        private void Accelerate()
        {
            float moveSpeed = BulletStatComponent.Speed;
            float maxMoveSpeed = BulletStatComponent.MaxSpeed;
            float minMoveSpeed = BulletStatComponent.MinSpeed;
            float minToMaxSeconds = BulletStatComponent.MinToMaxSpeedSeconds;
            if (moveSpeed >= maxMoveSpeed || minToMaxSeconds <= 0f) return;
            
            BulletStatComponent.IncreaseSpeed((maxMoveSpeed - minMoveSpeed) / minToMaxSeconds * Time.deltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;
            
            bool result = otherHitbox.Hit(transform.up, BulletStatComponent.Damage + _extraDamage, EnemyTags);
            if (result) Destroy(gameObject);
        }
    }
}
