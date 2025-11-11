using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Player.Component
{
    [RequireComponent(typeof(PlayerStatComponent), typeof(InvincibleComponent))]
    public class PlayerSkillComponent : MonoBehaviour
    {
        private InvincibleComponent _invincibleComponent;

        public float InvincibleSeconds = 3f;

        private void Start()
        {
            _invincibleComponent = GetComponent<InvincibleComponent>();
        }

        public void Activate()
        {
            _invincibleComponent.Activate(InvincibleSeconds);
        }
    }
}