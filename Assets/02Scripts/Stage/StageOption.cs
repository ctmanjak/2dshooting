using System;
using _02Scripts.Enemy;

namespace _02Scripts.Stage
{
    [Serializable]
    public class StageOption
    {
        public StageSpawnerOption[] SpawnerOptions;
        public int RequireScoreToNext;
        public float HealthMultiplier = 1f;
        public bool UseAutoBalance;
    }
    
    [Serializable]
    public class StageSpawnerOption
    {
        public EnemySpawner Spawner;
        public SpawnerOption[] SpawnerOptions;
    }
}