using _02Scripts.Player;
using _02Scripts.Score;
using UnityEngine;

namespace _02Scripts.UI
{
    public class UpgradeManager : MonoBehaviour
    {
        public static UpgradeManager Instance { get; private set; }

        public PlayerEntity Player;

        public int SubtractScoreAmount = 1000;
        public int IncreaseDamageUpAmount = 100;
        public int UpgradeLevel = 1;

        private void Awake()
        {
            Instance = this;
        }   

        public void Upgrade()
        {
            ScoreManager.Instance.SubtractScore(SubtractScoreAmount);
            Upgrade(1);
        }

        private void Upgrade(int level)
        {
            Player.IncreaseDamage(IncreaseDamageUpAmount * level);
            UpgradeLevel += level;
        }

        public void Load(UserData userData)
        {
            Upgrade(userData.UpgradeLevel - 1);
        }
    }
}