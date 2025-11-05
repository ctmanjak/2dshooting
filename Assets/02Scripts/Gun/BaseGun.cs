using _02Scripts.Bullet;
using UnityEngine;

namespace _02Scripts.Gun
{
    public abstract class BaseGun : MonoBehaviour
    {
        public BaseBullet BulletPrefab;
    
        [Header("스탯")]
        public int BaseDamage;
        public float FireCooldown = 1.0f;
        private float _lastFireTime;

        private void Start()
        {
            _lastFireTime = Time.time - FireCooldown;
        }
    
        public void Fire(int extraDamage = 0)
        {
            if (Time.time - _lastFireTime >= FireCooldown)
            {
                InstantiateBullet(BaseDamage + extraDamage, transform.position, transform.rotation);

                _lastFireTime = Time.time;
            }
        }

        protected virtual void InstantiateBullet(int damage, Vector3 position, Quaternion rotation)
        {
            BaseBullet bullet = Instantiate(BulletPrefab);
            bullet.Init(damage, position, rotation);
            bullet.transform.position = transform.position;
        }
    }
}
