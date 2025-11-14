using _02Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace _02Scripts.UI
{
    public class PlayerHealthUIController : MonoBehaviour
    {
        [SerializeField] private Text _playerHealthTextUI;

        public PlayerEntity Player;

        private void Awake()
        {
            if (!Player) return;
            
            Player.OnHealthChanged(UpdatePlayerHealthText);
        }

        private void UpdatePlayerHealthText(int health)
        {
            if (!_playerHealthTextUI) return;
            _playerHealthTextUI.text = health.ToString("N0");
        }
    }
}