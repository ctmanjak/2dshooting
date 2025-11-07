using System.Linq;
using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _timer;
        private float _coolTime;

        public float MinInclusive = 1f;
        public float MaxInclusive = 3f;

        public SpawnerOption[] SpawnerOptions;
        
        private void Start()
        {
            SetRandomCoolTime(MinInclusive, MaxInclusive);
        }
        
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= _coolTime)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            _timer = 0f;

            GameObject selectedPrefab = RandomUtil.PickWeightedRandomIndex(SpawnerOptions)?.Prefab;
            if (!selectedPrefab) return;
            
            GameObject enemyObject = Instantiate(selectedPrefab);
            enemyObject.transform.position = transform.position;

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