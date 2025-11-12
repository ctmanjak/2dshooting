using System;
using _02Scripts.Bullet;
using UnityEngine;

namespace _02Scripts.Gun
{
    public abstract class BaseGun : MonoBehaviour
    {
        public event Action OnFire;
        
        [Header("스탯")]
        public int BaseDamage;
        public float FireCooldown = 1.0f;
        private float _lastFireTime;

        private void Start()
        {
            _lastFireTime = Time.time - FireCooldown;
        }

        public void Fire(int extraDamage, Vector2 direction, float attackSpeed)
        {
            if (!(Time.time - _lastFireTime >= FireCooldown / attackSpeed)) return;
            DoFire(extraDamage, direction);
            OnFire?.Invoke();
            _lastFireTime = Time.time;
        }

        protected abstract void DoFire(int extraDamage, Vector2 direction);

        public abstract void SetBulletPrefab(BaseBullet bulletPrefab);
    }
}