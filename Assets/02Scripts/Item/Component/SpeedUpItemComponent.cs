using _02Scripts.Common.Component;
using _02Scripts.Player.Component;
using UnityEngine;

namespace _02Scripts.Item.Component
{
    public class SpeedUpItemComponent : MonoBehaviour
    {
        public int IncreaseValue = 1;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
        
            PlayerStatComponent otherStat = other.GetComponent<PlayerStatComponent>();
            if (otherStat == null) return;

            otherStat.IncreaseSpeed(IncreaseValue);
        
            Destroy(gameObject);
        }
    }
}