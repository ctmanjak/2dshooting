using System.Collections.Generic;
using System.Linq;
using _02Scripts.Enemy.Factory;
using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _lastSpawnTime;
        private float _coolTime;

        public float MinInclusive = 1f;
        public float MaxInclusive = 3f;

        public SpawnerOption[] SpawnerOptions;
        
        private readonly List<SpawnerOption> _spawnerOptions = new();
        
        private void Start()
        {
            SetRandomCoolTime(MinInclusive, MaxInclusive);
        }

        public void Spawn()
        {
            float currentTime = Time.time;
            if (currentTime - _lastSpawnTime < _coolTime) return;
            _lastSpawnTime = currentTime;

            _spawnerOptions.Clear();
            foreach (var option in SpawnerOptions)
            {
                if (option.IsSpawnable()) _spawnerOptions.Add(option);
            }
            if (_spawnerOptions.Count < 1) return;
            
            SpawnerOption selectedOption = RandomUtil.PickWeightedRandomIndex(_spawnerOptions.ToArray());
            selectedOption.CountDown();
            
            EnemyEntity selectedPrefab = selectedOption.Prefab;
            if (!selectedPrefab) return;
            
            EnemyEntity enemyEntity = EnemyFactory.Instance.Spawn(selectedPrefab, transform.position, Quaternion.identity);
            enemyEntity.Init();


            SetRandomCoolTime(MinInclusive, MaxInclusive);
        }
        
        public void SetSpawnerOption(SpawnerOption[] options)
        {
            SpawnerOptions = options;
            foreach (var option in SpawnerOptions)
            {
                option.Init();
            }
        }
        
        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        
        private void SetRandomCoolTime(float minInclusive, float maxInclusive)
        {
            SetCoolTime(Random.Range(minInclusive, maxInclusive));
        }

        private void SetCoolTime(float coolTime)
        {
            _coolTime = coolTime;
        }
    }
}