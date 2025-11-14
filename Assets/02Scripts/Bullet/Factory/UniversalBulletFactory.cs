using _02Scripts.Common.Factory;

namespace _02Scripts.Bullet.Factory
{
    public class UniversalBulletFactory : PoolFactory<BaseBullet>
    {
        public static UniversalBulletFactory Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}