using UnityEngine;

namespace _02Scripts.Bullet
{
    public class SnakeBullet : BaseBullet
    {
        public float RotateSpeed = 10.0f;
        public float TurnAngle = 40.0f;
        
        private Vector3 _rotateDirection = Vector3.back;
        
        protected override void Move()
        {
            if (transform.rotation.eulerAngles.z >= TurnAngle && transform.rotation.eulerAngles.z <= 360.0f - TurnAngle)
            {
                _rotateDirection *= -1;
            }
            transform.rotation *= Quaternion.AngleAxis(RotateSpeed * Time.deltaTime, _rotateDirection);
            
            base.Move();
        }
    }
}