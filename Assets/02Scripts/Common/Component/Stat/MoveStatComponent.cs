using UnityEngine;

namespace _02Scripts.Common.Component.Stat
{
    public class MoveStatComponent : MonoBehaviour
    {
        [SerializeField] private float Speed = 5.0f;
        public float MaxSpeed = 10f;
        public float MinSpeed = 3f;
        public float SpeedMultiplier = 1.0f;
        
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

        public void SetSpeed(float speed)
        {
            Speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);
        }
    }
}