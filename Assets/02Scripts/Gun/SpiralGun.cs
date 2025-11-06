using _02Scripts.Bullet;
using UnityEngine;

namespace _02Scripts.Gun
{
    public class SpiralGun : GenericBaseGun<NormalBullet>
    {
        public float RotateSpeed = 10.0f;

        public override void InstantiateBullet(int damage, Vector3 position, Quaternion rotation)
        {
            base.InstantiateBullet(damage, position, rotation);
        
            transform.rotation *= Quaternion.AngleAxis(RotateSpeed, Vector3.forward);
        }
    }
}
