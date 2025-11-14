using System;
using UnityEngine;

namespace _02Scripts.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }

        public int Score { get; private set; }

        public int HighScore { get; private set; }

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
            
            SetScore(Score + amount);
            
            if (Score <= HighScore) return;
            OnHighScore?.Invoke();
            SetHighScore(Score);
        }

        public void SubtractScore(int amount)
        {
            if (amount < 1) return;
            
            SetScore(Score - amount);
        }

        public void Load(int score, int highScore)
        {
            SetScore(score);
            SetHighScore(highScore);
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

        public void Save(UserData userData)
        {
            userData.Score = Score;
            userData.HighScore = HighScore;
        }
    }
}
