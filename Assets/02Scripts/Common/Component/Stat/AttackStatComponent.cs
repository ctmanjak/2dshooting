using UnityEngine;

namespace _02Scripts.Common.Component.Stat
{
    public class AttackStatComponent : MonoBehaviour
    {
        public int Damage = 10;
        [SerializeField] private float AttackSpeed = 1f;
        
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