using _02Scripts.Common.Factory;

namespace _02Scripts.Bullet.Factory
{
    public abstract class BulletFactory<T> : SinglePoolFactory<T> where T : BaseBullet
    {
        public static BulletFactory<T> Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}