using System;
using _02Scripts.Common.Component;
using _02Scripts.Common.Component.Stat;
using _02Scripts.Player.Component;
using _02Scripts.Score;
using UnityEngine;

namespace _02Scripts.Player
{
    [RequireComponent(typeof(HealthComponent), typeof(PlayerSkillComponent), typeof(AttackStatComponent))]
    public class PlayerEntity : MonoBehaviour
    {
        private HealthComponent _healthComponent;
        private PlayerSkillComponent _playerSkillComponent;
        private AttackStatComponent _attackStatComponent;

        public int DamageWhenUseSkill = 10;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _playerSkillComponent = GetComponent<PlayerSkillComponent>();
            _attackStatComponent = GetComponent<AttackStatComponent>();
        }

        public void UseSkill()
        {
            _healthComponent.TakeDamage(DamageWhenUseSkill);
            _playerSkillComponent.Activate();
        }

        public void IncreaseDamage(int amount)
        {
            _attackStatComponent.IncreaseDamage(amount);
        }

        public void OnHealthChanged(Action<int> action)
        {
            _healthComponent.ChangeHealth += action;
        }

        public int GetHealth()
        {
            return _healthComponent.Health;
        }

        public void Load(UserData userData)
        {
            _healthComponent.SetHealth(userData.Health);
        }
    }
}