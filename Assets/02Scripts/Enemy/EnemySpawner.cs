using UnityEngine;

namespace _02Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        private float _timer;
        private float _coolTime;

        public GameObject EnemyPrefab;
        
        private void Start()
        {
            SetRandomCoolTime(1f, 2f);
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
            enemyObject.transform.position = transform.position;

            SetRandomCoolTime(1f, 3f);
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