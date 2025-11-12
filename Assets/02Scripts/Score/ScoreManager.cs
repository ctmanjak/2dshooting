using System;
using UnityEngine;

namespace _02Scripts.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance;
        
        private int _score;
        private int _highScore;

        private const string HighScoreKey = "HighScore";

        public event Action OnHighScore;
        public event Action<int> OnScoreChanged;
        public event Action<int> OnHighScoreChanged;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Load();
            OnScoreChanged?.Invoke(_score);
            OnHighScoreChanged?.Invoke(_highScore);
        }

        public void AddScore(int amount)
        {
            if (amount < 1) return;
            
            _score += amount;
            OnScoreChanged?.Invoke(_score);
            
            if (_score <= _highScore) return;
            OnHighScore?.Invoke();
            _highScore = _score;
            OnHighScoreChanged?.Invoke(_highScore);
            Save();
        }
        
        private void Save()
        {
            PlayerPrefs.SetString(HighScoreKey, JsonUtility.ToJson(new UserData(_highScore)));
        }

        private void Load()
        {
            UserData userData = JsonUtility.FromJson<UserData>(PlayerPrefs.GetString(HighScoreKey));

            if (userData == null) return;
            _highScore = userData.HighScore;
        }
    }
}
