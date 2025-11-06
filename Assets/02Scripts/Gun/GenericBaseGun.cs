using _02Scripts.Bullet;
using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Gun
{
    public abstract class GenericBaseGun<T> : BaseGun where T : BaseBullet
    {
        public T BulletPrefab;
        
        [Header("스탯")]
        public int BaseDamage;
        public float FireCooldown = 1.0f;
        private float _lastFireTime;

        private void Start()
        {
            _lastFireTime = Time.time - FireCooldown;
        }

        public override void Fire(int extraDamage, Vector2 direction)
        {
            if (Time.time - _lastFireTime >= FireCooldown)
            {
                Quaternion rotation = MathUtil.DirectionToQuaternion(direction, -90f);
                InstantiateBullet(BaseDamage + extraDamage, rotation);

                _lastFireTime = Time.time;
            }
        }

        protected virtual void InstantiateBullet(int damage, Quaternion rotation)
        {
            T bullet = Instantiate(BulletPrefab, transform.position, transform.rotation);
            bullet.Init(damage, rotation);
        }

        public override void SetBulletPrefab(BaseBullet bulletPrefab)
        {
            BulletPrefab = (T)bulletPrefab;
        }
    }
}
