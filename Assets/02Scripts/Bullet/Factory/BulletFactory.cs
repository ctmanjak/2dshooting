using _02Scripts.Common.Factory;
using UnityEngine;

namespace _02Scripts.Bullet.Factory
{
    public abstract class BulletFactory<T> : PoolFactory where T : BaseBullet
    {
        public static BulletFactory<T> Instance { get; private set; }

        protected override void Init()
        {
            base.Init();

            Instance = this;
        }
        
        public T InstantiateBullet(Vector3 position, Quaternion rotation)
        {
            T bullet = InstantiateObject<T>(position, rotation);

            return bullet;
        }
    }
}