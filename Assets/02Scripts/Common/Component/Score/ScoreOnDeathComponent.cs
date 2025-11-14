using _02Scripts.Score;
using UnityEngine;

namespace _02Scripts.Common.Component.Score
{
    [RequireComponent(typeof(DeathComponent))]
    public class ScoreOnDeathComponent : MonoBehaviour
    {
        private DeathComponent _deathComponent;

        public int Score = 100;

        private void Awake()
        {
            _deathComponent = GetComponent<DeathComponent>();
        }

        private void Start()
        {
            _deathComponent.OnDie += OnDie;
        }

        private void OnDie(GameObject obj)
        {
            ScoreManager.Instance.AddScore(Score);
        }
    }
}