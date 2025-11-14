using _02Scripts.Common.Factory;

namespace _02Scripts.Enemy.Factory
{
    public class EnemyFactory : PoolFactory<EnemyEntity>
    {
        public static EnemyFactory Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}