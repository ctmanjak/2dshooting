using _02Scripts.Common.Factory;

namespace _02Scripts.Item.Factory
{
    public class ItemFactory : PoolFactory<ItemEntity>
    {
        public static ItemFactory Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}