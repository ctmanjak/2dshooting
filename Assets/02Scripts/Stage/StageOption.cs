using System;
using _02Scripts.Enemy;

namespace _02Scripts.Stage
{
    [Serializable]
    public class StageOption
    {
        public StageSpawnerOption[] SpawnerOptions;
        public int RequireScoreToNext;
    }
    
    [Serializable]
    public class StageSpawnerOption
    {
        public EnemySpawner Spawner;
        public SpawnerOption[] SpawnerOptions;
    }
}