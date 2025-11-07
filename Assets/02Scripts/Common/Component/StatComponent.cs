using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class StatComponent : MonoBehaviour
    {
        public int MaxHealth = 100;
        
        public int Damage = 10;
        [SerializeField] private float AttackSpeed = 1f;
        
        [SerializeField] private float Speed = 5.0f;
        public float MaxSpeed = 10f;
        public float MinSpeed = 3f;
        public float SpeedMultiplier = 1.0f;

        public float InvincibleSeconds;
        
        public void IncreaseSpeed(float value)
        {
            SetSpeed(Speed + value);
        }

        public void DecreaseSpeed(float value)
        {
            SetSpeed(Speed - value);
        }

        public float GetSpeed()
        {
            return Speed;
        }

        private void SetSpeed(float speed)
        {
            Speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);
        }

        public float GetAttackSpeed()
        {
            return AttackSpeed;
        }

        public void IncreaseAttackSpeed(float amount)
        {
            AttackSpeed += amount;
        }
    }
}