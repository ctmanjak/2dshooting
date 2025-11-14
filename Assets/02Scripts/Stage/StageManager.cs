using _02Scripts.Enemy;
using _02Scripts.Score;
using UnityEngine;

namespace _02Scripts.Stage
{
    public class StageManager : MonoBehaviour
    {
        public StageOption[] StageOptions;

        private int _stageNum = -1;

        private int _accumulateRequiredScore;

        private void Start()
        {
            NextWave();
        }

        private void Update()
        {
            SpawnWave();
            
            if (_stageNum + 1 >= StageOptions.Length) return;
            
            StageOption stage = StageOptions[_stageNum];
            if (ScoreManager.Instance.Score < _accumulateRequiredScore + stage.RequireScoreToNext) return;
            
            EndWave();
            NextWave();
            InitWave();
        }

        private void InitWave()
        {
            StageOption stage = StageOptions[_stageNum];
            foreach (var stageSpawnerOption in stage.SpawnerOptions)
            {
                stageSpawnerOption.Spawner.SpawnerOptions = stageSpawnerOption.SpawnerOptions;
                stageSpawnerOption.Spawner.gameObject.SetActive(true);
                foreach (var spawnerSpawnerOption in stageSpawnerOption.Spawner.SpawnerOptions)
                {
                    spawnerSpawnerOption.Init();
                }
            }
        }

        private void NextWave()
        {
            _stageNum++;
        }

        private void EndWave()
        {
            StageOption stage = StageOptions[_stageNum];
            foreach (var stageSpawnerOption in stage.SpawnerOptions)
            {
                stageSpawnerOption.Spawner.gameObject.SetActive(false);
            }

            _accumulateRequiredScore += stage.RequireScoreToNext;
        }

        private void SpawnWave()
        {
            StageOption stage = StageOptions[_stageNum];
            foreach (var stageSpawnerOption in stage.SpawnerOptions)
            {
                stageSpawnerOption.Spawner.Spawn();
            }
        }
    }
}