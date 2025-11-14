using _02Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace _02Scripts.UI
{
    public class ButtonUIController : MonoBehaviour
    {
        [SerializeField] private Button _damageUpButtonUI;
        [SerializeField] private Button _skillButtonUI;

        public PlayerEntity Player;

        private void Start()
        {
            if (!Player) return;
            _damageUpButtonUI.onClick.AddListener(() =>
            {
                UpgradeManager.Instance.Upgrade();
            });

            _skillButtonUI.onClick.AddListener(() =>
            {
                Player.UseSkill();
            });
        }
    }
}