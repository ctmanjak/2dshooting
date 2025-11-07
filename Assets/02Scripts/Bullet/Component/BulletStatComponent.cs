using UnityEngine;

namespace _02Scripts.Bullet.Component
{
    public class BulletStatComponent : MonoBehaviour
    {
        public int Damage = 10;
        public float Speed { get; private set; } = 5.0f;
        public float MinSpeed = 3f;
        public float MaxSpeed = 10f;
        public float MinToMaxSpeedSeconds = 1.2f;
        
        public void IncreaseSpeed(float value)
        {
            SetSpeed(Speed + value);
        }

        public void SetSpeed(float speed)
        {
            Speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);
        }
    }
}