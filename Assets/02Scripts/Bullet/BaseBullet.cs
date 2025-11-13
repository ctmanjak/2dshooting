using _02Scripts.Bullet.Component;
using _02Scripts.Common;
using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Bullet
{
    [RequireComponent(typeof(MoveComponent), typeof(MoveStatComponent), typeof(BulletStatComponent))]
    public abstract class BaseBullet : MonoBehaviour, IDestroyable
    {
        private MoveComponent _moveComponent;
        private BulletStatComponent _bulletStatComponent;
        private MoveStatComponent _moveStatComponent;

        private int _extraDamage;

        protected string[] EnemyTags = { "Enemy" };

        protected virtual void Awake()
        {
            Init();
        }

        private void Init()
        {
            _moveComponent = GetComponent<MoveComponent>();
            _moveComponent.SetAfterMove(AfterMove);

            _moveStatComponent = GetComponent<MoveStatComponent>();
            _bulletStatComponent = GetComponent<BulletStatComponent>();
        }
        private void FixedUpdate()
        {
            Accelerate();
        }

        public virtual void Init(int damage, Quaternion? rotation = null)
        {
            _moveStatComponent.SetSpeed(_moveStatComponent.MinSpeed);
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
            float moveSpeed = _moveStatComponent.GetSpeed();
            float maxMoveSpeed = _moveStatComponent.MaxSpeed;
            float minToMaxSeconds = _bulletStatComponent.MinToMaxSpeedSeconds;
            if (moveSpeed >= maxMoveSpeed || minToMaxSeconds <= 0f) return;
            
            float minMoveSpeed = _moveStatComponent.MinSpeed;
            _moveStatComponent.IncreaseSpeed((maxMoveSpeed - minMoveSpeed) / minToMaxSeconds * Time.deltaTime);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            HitboxComponent otherHitbox = other.GetComponent<HitboxComponent>();
            if (otherHitbox == null) return;
            
            bool result = otherHitbox.Hit(transform.up, _bulletStatComponent.Damage + _extraDamage, EnemyTags);
            if (result) DestroySelf();
        }

        public void DestroySelf()
        {
            if (TryGetComponent<PooledMarkerComponent>(out _))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
