using UnityEngine;

namespace _02Scripts.Gun
{
    public class SpiralGun : BaseGun
    {
        public float RotateSpeed = 10.0f;

        protected override void InstantiateBullet(int damage, Vector3 position, Quaternion rotation)
        {
            base.InstantiateBullet(damage, position, rotation);
        
            transform.rotation *= Quaternion.AngleAxis(RotateSpeed, Vector3.forward);
        }
    }
}
