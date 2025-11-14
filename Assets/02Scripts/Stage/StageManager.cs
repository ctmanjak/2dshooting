using System.Collections.Generic;
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
            ScoreManager.Instance.OnScoreChanged += CheckNextWave;
            NextWave();
            InitWave();
        }

        private void Update()
        {
            SpawnWave();
        }
        
        private void CheckNextWave(int score)
        {
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
                stageSpawnerOption.Spawner.SetSpawnerOption(stageSpawnerOption.SpawnerOptions);
                stageSpawnerOption.Spawner.Activate();
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
                stageSpawnerOption.Spawner.Deactivate();
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