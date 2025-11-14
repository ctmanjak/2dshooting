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
        
        private void Start()
        {
            SetRandomCoolTime(MinInclusive, MaxInclusive);
        }
        
        // private void Update()
        // {
        //     _lastSpawnTime += Time.deltaTime;
        //
        //     if (_lastSpawnTime >= _coolTime)
        //     {
        //         Spawn();
        //     }
        // }

        public void Spawn()
        {
            float currentTime = Time.time;
            if (currentTime - _lastSpawnTime < _coolTime) return;
            _lastSpawnTime = currentTime;

            SpawnerOption[] options = SpawnerOptions.Where(option => option.IsSpawnable()).ToArray();
            if (options.Length < 1) return;
            
            SpawnerOption selectedOption = RandomUtil.PickWeightedRandomIndex(options);
            selectedOption.CountDown();
            
            EnemyEntity selectedPrefab = selectedOption.Prefab;
            if (!selectedPrefab) return;
            
            EnemyEntity enemyEntity = EnemyFactory.Instance.Spawn(selectedPrefab, transform.position, Quaternion.identity);
            enemyEntity.Init();


            SetRandomCoolTime(MinInclusive, MaxInclusive);
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