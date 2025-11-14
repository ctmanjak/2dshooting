using System;
using UnityEngine;

namespace _02Scripts.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int Score { get; private set; }

        public int HighScore { get; private set; }

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
            OnScoreChanged?.Invoke(Score);
            OnHighScoreChanged?.Invoke(HighScore);
        }

        public void AddScore(int amount)
        {
            if (amount < 1) return;
            
            Score += amount;
            OnScoreChanged?.Invoke(Score);
            
            if (Score <= HighScore) return;
            OnHighScore?.Invoke();
            HighScore = Score;
            OnHighScoreChanged?.Invoke(HighScore);
        }

        public void SubtractScore(int amount)
        {
            if (amount < 1) return;
            
            Score -= amount;
            OnScoreChanged?.Invoke(Score);
            
            if (Score <= HighScore) return;
            OnHighScore?.Invoke();
            HighScore = Score;
            OnHighScoreChanged?.Invoke(HighScore);
        }

        public void Load(UserData userData)
        {
            SetScore(userData.Score);
            SetHighScore(userData.HighScore);
        }

        private void SetScore(int score)
        {
            Score = score;
            OnScoreChanged?.Invoke(Score);
        }

        private void SetHighScore(int highScore)
        {
            HighScore = highScore;
            OnHighScoreChanged?.Invoke(HighScore);
        }
    }
}
