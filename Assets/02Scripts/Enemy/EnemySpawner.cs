using _02Scripts.Common;
using UnityEngine;

namespace _02Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _timer;
        private float _coolTime;
        private GameObject _player;

        public float MinInclusive = 1f;
        public float MaxInclusive = 3f;

        public float FollowEnemySpawnChance = 0.3f; 

        public GameObject EnemyPrefab;
        
        private void Start()
        {
            SetRandomCoolTime(MinInclusive, MaxInclusive);
            _player = GameObject.FindWithTag("Player");
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
            GameObject enemyObject = Instantiate(EnemyPrefab);
            if (Random.value <= FollowEnemySpawnChance)
            {
                EnemyAIComponent enemyAIComponent = enemyObject.GetComponent<EnemyAIComponent>();
                enemyAIComponent.SetTarget(_player);
            }
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