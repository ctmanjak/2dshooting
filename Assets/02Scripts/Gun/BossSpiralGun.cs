using _02Scripts.Bullet;
using UnityEngine;

namespace _02Scripts.Gun
{
    public class BossSpiralGun : GenericBaseGun<BossSpiralBullet>
    {
        public float RotateSpeed = 10.0f;

        protected override void FireBullet(int damage, Quaternion rotation)
        {
            base.FireBullet(damage, transform.rotation);
        
            transform.rotation *= Quaternion.AngleAxis(RotateSpeed, Vector3.forward);
        }
    }
}
