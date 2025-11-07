using _02Scripts.Bullet.Component;
using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Bullet
{
    [RequireComponent(typeof(MoveComponent), typeof(MoveStatComponent), typeof(BulletStatComponent))]
    public abstract class BaseBullet : MonoBehaviour
    {
        private MoveComponent _moveComponent;
        private BulletStatComponent _bulletStatComponent;
        protected MoveStatComponent MoveStatComponent;

        private int _extraDamage;

        protected string[] EnemyTags = { "Enemy" };

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _moveComponent.SetAfterMove(AfterMove);

            MoveStatComponent = GetComponent<MoveStatComponent>();
            _bulletStatComponent = GetComponent<BulletStatComponent>();
        }
        private void FixedUpdate()
        {
            Accelerate();
            _moveComponent.Rotate(GetRotation());
            _moveComponent.Move(transform.up, MoveStatComponent.GetSpeed() * Time.deltaTime);
        }

        public virtual void Init(int damage = 0, Quaternion? rotation = null)
        {
            MoveStatComponent.SetSpeed(MoveStatComponent.MinSpeed);
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
            float moveSpeed = MoveStatComponent.GetSpeed();
            float maxMoveSpeed = MoveStatComponent.MaxSpeed;
            float minMoveSpeed = MoveStatComponent.MinSpeed;
            float minToMaxSeconds = _bulletStatComponent.MinToMaxSpeedSeconds;
            if (moveSpeed >= maxMoveSpeed || minToMaxSeconds <= 0f) return;
            
            MoveStatComponent.IncreaseSpeed((maxMoveSpeed - minMoveSpeed) / minToMaxSeconds * Time.deltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;
            
            bool result = otherHitbox.Hit(transform.up, _bulletStatComponent.Damage + _extraDamage, EnemyTags);
            if (result) Destroy(gameObject);
        }
    }
}
