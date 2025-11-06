using _02Scripts.Bullet;
using UnityEngine;

namespace _02Scripts.Gun
{
    public class SpiralGun : GenericBaseGun<BaseBullet>
    {
        public float RotateSpeed = 10.0f;

        protected override void InstantiateBullet(int damage, Quaternion rotation)
        {
            base.InstantiateBullet(damage, rotation);
        
            transform.rotation *= Quaternion.AngleAxis(RotateSpeed, Vector3.forward);
        }
    }
}
