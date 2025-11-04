using UnityEngine;

namespace _02Scripts.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public Camera MainCamera;
    
        private Vector2 _movableTopRight;
        private Vector2 _movableBottomLeft;

        private Vector2 _initialPosition;
    
        [Header("능력치")]
        public float Speed = 5f;
        public float MaxSpeed = 10f;
        public float MinSpeed = 3f;
        public float SpeedChangeAmount = 5f;
        public float SpeedMultiplier = 1.2f;
    
        void Start()
        {
            if (MainCamera == null) MainCamera = Camera.main;

            if (MainCamera != null)
            {
                _movableTopRight = MainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, MainCamera.nearClipPlane));
                _movableBottomLeft = MainCamera.ViewportToWorldPoint(new Vector3(0, 0, MainCamera.nearClipPlane));
            }

            _initialPosition = transform.position;
        }

        void Update()
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            AdjustSpeed();

            float speedDelta = Speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.LeftShift)) speedDelta *= SpeedMultiplier;
        
            Vector2 position = transform.position;
            Vector2 direction = new Vector2(h, v).normalized;
            if (Input.GetKey(KeyCode.R))
            {
                direction = (_initialPosition - position).normalized;
                Translate(direction, speedDelta);
                return;
            }
        
            Debug.Log($"direction: ({direction.x}, {direction.y})");
        
            Move(direction, speedDelta);
        }

        private void Translate(Vector2 direction, float speedDelta)
        {
            transform.Translate(direction * speedDelta);
        
            Vector2 position = transform.position;
            if (direction.x > 0 && transform.position.x > _initialPosition.x ||
                direction.x < 0 && transform.position.x < _initialPosition.x)
            {
                position.x = _initialPosition.x;
            }

            if (direction.y > 0 && transform.position.y > _initialPosition.y ||
                direction.y < 0 && transform.position.y < _initialPosition.y)
            {
                position.y = _initialPosition.y;
            }

            transform.position = position;
        }

        private void AdjustSpeed()
        {
            if (Input.GetKey(KeyCode.Q)) Speed += SpeedChangeAmount * Time.deltaTime;
            else if (Input.GetKey(KeyCode.E)) Speed -= SpeedChangeAmount * Time.deltaTime;
            Speed = Mathf.Clamp(Speed, MinSpeed, MaxSpeed);
        }

        private Vector2 CheckMoveBoundary(Vector2 position)
        {
            position.x = Mathf.Clamp(position.x, _movableBottomLeft.x, _movableTopRight.x);
            position.y = Mathf.Clamp(position.y, _movableBottomLeft.y, _movableTopRight.y);

            return position;
        }

        private void Move(Vector2 direction, float speedDelta)
        {
            Vector2 newPosition = (Vector2)transform.position + direction * speedDelta;
            newPosition = CheckMoveBoundary(newPosition);
        
            if (newPosition.x <= _movableBottomLeft.x)
            {
                newPosition.x = _movableTopRight.x - Mathf.Epsilon;
            } else if (newPosition.x >= _movableTopRight.x)
            {
                newPosition.x = _movableBottomLeft.x + Mathf.Epsilon;
            }
            Debug.Log($"newPosition: ({newPosition.x}, {newPosition.y})");

            transform.position = newPosition;
        }
    }
}
