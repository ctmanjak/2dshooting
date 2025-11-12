using UnityEngine;
using UnityEngine.UI;

namespace _02Scripts.Score
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private Text _scoreTextUI;

        private int _score = 0;

        private const string ScoreKey = "Score";
        
        private void Start()
        {
            if (!_scoreTextUI) return;
            
            Load();
            
            UpdateScoreText();
        }

        public void AddScore(int amount)
        {
            if (amount < 1) return;
            _score += amount;
            
            UpdateScoreText();
            
            Save();
        }

        private void UpdateScoreText()
        {
            _scoreTextUI.text = $"현재 점수 : {_score:N0}";
        }
        
        private void Save()
        {
            PlayerPrefs.SetInt(ScoreKey, _score);
        }

        private void Load()
        {
            _score = PlayerPrefs.GetInt(ScoreKey);
        }
    }
}
