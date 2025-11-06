using UnityEngine;

namespace _02Scripts.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        public float Speed = 5.0f;

        // Update is called once per frame
        void Update()
        {
            Vector2 position = transform.position;
            Vector2 newPosition = position + Vector2.down * (Speed * Time.deltaTime);
            transform.position = newPosition;
        }
    }
}
