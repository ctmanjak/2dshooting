using _02Scripts.Bullet;
using _02Scripts.Util;
using Unity.Mathematics.Geometry;
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
                InstantiateBullet(BaseDamage + extraDamage, transform.position, MathUtil.DirectionToQuaternion(direction, -90f));

                _lastFireTime = Time.time;
            }
        }

        public override void InstantiateBullet(int damage, Vector3 position, Quaternion rotation)
        {
            T bullet = Instantiate(BulletPrefab);
            bullet.Init(damage, position, rotation);
        }

        public override void SetBulletPrefab(BaseBullet bulletPrefab)
        {
            BulletPrefab = (T)bulletPrefab;
        }
    }
}
