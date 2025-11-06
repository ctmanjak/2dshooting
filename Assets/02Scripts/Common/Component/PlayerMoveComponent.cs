using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class PlayerMoveComponent : MoveComponent
    {
        public Camera MainCamera;
        
        private Vector2 _movableTopRight;
        private Vector2 _movableBottomLeft;
        
        public override void Move(Vector2 direction, float speed)
        {
            base.Move(direction, speed);

            transform.position = HandlePlayerPosition(transform.position);
        }
        
        private void Start()
        {
            if (MainCamera == null) MainCamera = Camera.main;
            if (MainCamera == null) return;
            
            _movableTopRight = MainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, MainCamera.nearClipPlane));
            _movableBottomLeft = MainCamera.ViewportToWorldPoint(new Vector3(0, 0, MainCamera.nearClipPlane));
        }

        private Vector2 HandlePlayerPosition(Vector2 position)
        {
            position.x = Mathf.Clamp(position.x, _movableBottomLeft.x, _movableTopRight.x);
            position.y = Mathf.Clamp(position.y, _movableBottomLeft.y, _movableTopRight.y);
            
            if (position.x <= _movableBottomLeft.x)
            {
                position.x = _movableTopRight.x - Mathf.Epsilon;
            } else if (position.x >= _movableTopRight.x)
            {
                position.x = _movableBottomLeft.x + Mathf.Epsilon;
            }
            
            return position;
        }
    }
}
