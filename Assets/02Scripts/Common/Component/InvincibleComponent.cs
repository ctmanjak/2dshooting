using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class InvincibleComponent : MonoBehaviour
    {
        private float _invincibleSeconds;
        private float _lastInvincibleTime;
        private bool _isInvincible;

        public void Activate(float invincibleSeconds)
        {
            _invincibleSeconds = invincibleSeconds;
            _lastInvincibleTime = Time.time;
            _isInvincible = true;
        }

        public bool IsInvincible()
        {
            if (!_isInvincible) return false;

            if (Time.time - _lastInvincibleTime <= _invincibleSeconds) return true;

            _isInvincible = false;
            return false;

        }
    }
}