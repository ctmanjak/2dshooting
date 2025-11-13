using _02Scripts.Bullet;
using _02Scripts.Bullet.Factory;
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
            FireBullet(BaseDamage + extraDamage, rotation);
        }

        protected virtual void FireBullet(int damage, Quaternion rotation)
        {
            InstantiateBullet(damage, transform.position, rotation);
        }

        protected T InstantiateBullet(int damage, Vector3 position, Quaternion rotation)
        {
            T bullet = !BulletFactory<T>.Instance
                ? Instantiate(BulletPrefab, position, rotation)
                : BulletFactory<T>.Instance.InstantiateBullet(position, rotation);
            bullet.Init(damage, rotation);

            return bullet;
        }

        public override void SetBulletPrefab(BaseBullet bulletPrefab)
        {
            BulletPrefab = (T)bulletPrefab;
        }
    }
}
