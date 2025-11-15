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
        
        private int _upgradeLevel = 1;

        private void Awake()
        {
            Instance = this;
        }   

        public void Upgrade()
        {
            if (ScoreManager.Instance.Score < SubtractScoreAmount) return;
            
            ScoreManager.Instance.SubtractScore(SubtractScoreAmount);
            Upgrade(1);
        }

        private void Upgrade(int level)
        {
            Player.IncreaseDamage(IncreaseDamageUpAmount * level);
            _upgradeLevel += level;
        }
        
        public void Save(UserData userData)
        {
            userData.UpgradeLevel = _upgradeLevel;
        }

        public void Load(int savedLevel)
        {
            if (savedLevel <= _upgradeLevel) return;

            int increaseLevel = savedLevel - _upgradeLevel;
            Player.IncreaseDamage(IncreaseDamageUpAmount * increaseLevel);
            _upgradeLevel = savedLevel;
        }
    }
}