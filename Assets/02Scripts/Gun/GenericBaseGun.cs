using _02Scripts.Bullet;
using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Gun
{
    public abstract class GenericBaseGun<T> : BaseGun where T : BaseBullet
    {
        public T BulletPrefab;

        private const float AngleOffset = -90f;

        protected override void DoFire(int extraDamage, Vector2 direction)
        {
            Quaternion rotation = MathUtil.DirectionToQuaternion(direction, AngleOffset);
            InstantiateBullet(BaseDamage + extraDamage, rotation);
        }

        protected virtual void InstantiateBullet(int damage, Quaternion rotation)
        {
            T bullet = Instantiate(BulletPrefab, transform.position, rotation);
            bullet.Init(damage, rotation);
        }

        public override void SetBulletPrefab(BaseBullet bulletPrefab)
        {
            BulletPrefab = (T)bulletPrefab;
        }
    }
}
