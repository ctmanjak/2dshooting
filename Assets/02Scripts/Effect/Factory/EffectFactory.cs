using _02Scripts.Common.Factory;

namespace _02Scripts.Effect.Factory
{
    public class EffectFactory : PoolFactory<EffectEntity>
    {
        public static EffectFactory Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }
    }
}