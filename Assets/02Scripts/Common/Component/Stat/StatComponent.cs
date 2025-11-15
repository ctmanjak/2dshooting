using UnityEngine;

namespace _02Scripts.Common.Component.Stat
{
    public class StatComponent : MonoBehaviour
    {
        public int MaxHealth = 100;
        public float InvincibleAfterHitSeconds;

        private int _defaultMaxHealth;

        private void Awake()
        {
            _defaultMaxHealth = MaxHealth;
        }
        
        public void Init(float healthMultiplier)
        {
            MaxHealth = Mathf.CeilToInt(_defaultMaxHealth * healthMultiplier);
        }
    }
}