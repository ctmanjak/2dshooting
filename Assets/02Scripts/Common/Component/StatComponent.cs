using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class StatComponent : MonoBehaviour
    {
        public int MaxHealth = 100;
        public int Damage = 10;
        public float Speed = 5.0f;

        public float InvincibleSeconds;
    }
}