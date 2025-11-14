namespace _02Scripts.Score
{
    public class UserData
    {
        public int HighScore;
        public int Score;
        public int Health;
        public int UpgradeLevel;

        public UserData(int highScore, int score, int health, int upgradeLevel)
        {
            HighScore = highScore;
            Score = score;
            Health = health;
            UpgradeLevel = upgradeLevel;
        }
    }
}