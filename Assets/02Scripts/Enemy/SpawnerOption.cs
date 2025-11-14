using System;
using _02Scripts.Common.Serializable;

namespace _02Scripts.Enemy
{
    [Serializable]
    public class SpawnerOption : WeightedRandomOption
    {
        public EnemyEntity Prefab;
        public bool UseSpawnLimit;
        public int MaxSpawnCount;

        private int _remainingSpawnCount;

        public void Init()
        {
            _remainingSpawnCount = MaxSpawnCount;
        }

        public bool IsSpawnable()
        {
            return !UseSpawnLimit || _remainingSpawnCount > 0;
        }

        public void CountDown()
        {
            _remainingSpawnCount = Math.Max(_remainingSpawnCount - 1, 0);
        }
    }
}