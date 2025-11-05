using UnityEngine;

namespace _02Scripts.Bullet
{
    public class SnakeBullet : BaseBullet
    {
        public float Frequency = 2.0f;
        public float TurnAngle = 40.0f;

        private float _time;
        
        protected override void Move()
        {
            _time += Time.deltaTime;

            float angle = TurnAngle * Mathf.Sin(_time * Mathf.PI * 2f * Frequency);
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
            
            base.Move();
        }
    }
}