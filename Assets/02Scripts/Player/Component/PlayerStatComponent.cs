using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Player.Component
{
    public class PlayerStatComponent : StatComponent
    {
        public Vector2 InitialPosition { get; private set; }
        
        public float MaxSpeed = 10f;
        public float MinSpeed = 3f;
        public float SpeedChangeAmount = 1f;

        private void Start()
        {
            InitialPosition = transform.position;
        }
        
        public void IncreaseSpeed()
        {
            SetSpeed(Speed + SpeedChangeAmount);
        }

        public void DecreaseSpeed()
        {
            SetSpeed(Speed - SpeedChangeAmount);
        }

        private void SetSpeed(float speed)
        {
            Speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);
        }
    }
}