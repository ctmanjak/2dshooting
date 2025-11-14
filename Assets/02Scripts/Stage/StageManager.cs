using _02Scripts.Score;
using UnityEngine;

namespace _02Scripts.Stage
{
    public class StageManager : MonoBehaviour
    {
        public StageOption[] StageOptions;

        private int _stageNum = -1;

        private int _accumulateRequiredScore;
        
        public float HpScaleFactor = 0.6f;
        public float ScoreFactor = 0.01f;

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
            while (true)
            {
                if (_stageNum + 1 >= StageOptions.Length) break;
                
                StageOption stage = StageOptions[_stageNum];
                if (ScoreManager.Instance.Score < _accumulateRequiredScore + stage.RequireScoreToNext) break;
                
                EndWave();
                NextWave();
            }
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
                float healthMultiplier = stage.UseAutoBalance
                    ? 1 + HpScaleFactor * Mathf.Log(1 + ScoreManager.Instance.Score * ScoreFactor)
                    : stage.HealthMultiplier;
                
                stageSpawnerOption.Spawner.Spawn(healthMultiplier);
            }
        }
    }
}