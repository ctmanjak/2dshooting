using System;
using _02Scripts.Common.Serializable;

namespace _02Scripts.Enemy
{
    [Serializable]
    public class SpawnerOption : WeightedRandomOption
    {
        public EnemyEntity Prefab;
    }
}