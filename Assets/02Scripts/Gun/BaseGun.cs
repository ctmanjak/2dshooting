using _02Scripts.Bullet;
using UnityEngine;

namespace _02Scripts.Gun
{
    public abstract class BaseGun : MonoBehaviour
    {
        public abstract void Fire(int extraDamage, Vector2 direction, float attackSpeed);

        public abstract void SetBulletPrefab(BaseBullet bulletPrefab);
    }
}