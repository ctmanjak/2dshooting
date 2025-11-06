using _02Scripts.Bullet;
using UnityEngine;

namespace _02Scripts.Gun
{
    public abstract class BaseGun : MonoBehaviour
    {
        public bool Enabled => gameObject.activeSelf;
        
        public abstract void Fire(int extraDamage);

        public abstract void InstantiateBullet(int damage, Vector3 position, Quaternion rotation);
    }
}