using _02Scripts.Score;
using UnityEngine;

namespace _02Scripts.Common.Component.Score
{
    [RequireComponent(typeof(DeathComponent))]
    public class ScoreOnDeathComponent : MonoBehaviour
    {
        private ScoreManager _scoreManager;
        private DeathComponent _deathComponent;

        public int Score = 100;

        private void Start()
        {
            _scoreManager = FindAnyObjectByType<ScoreManager>();
            _deathComponent = GetComponent<DeathComponent>();
            _deathComponent.OnDie += OnDie;
        }

        private void OnDie(GameObject obj)
        {
            _scoreManager.AddScore(Score);
        }
    }
}