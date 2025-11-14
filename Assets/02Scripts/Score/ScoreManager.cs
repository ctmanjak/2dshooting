using System;
using UnityEngine;

namespace _02Scripts.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int Score { get; private set; }

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
            OnScoreChanged?.Invoke(Score);
            OnHighScoreChanged?.Invoke(_highScore);
        }

        public void AddScore(int amount)
        {
            if (amount < 1) return;
            
            Score += amount;
            OnScoreChanged?.Invoke(Score);
            
            if (Score <= _highScore) return;
            OnHighScore?.Invoke();
            _highScore = Score;
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
