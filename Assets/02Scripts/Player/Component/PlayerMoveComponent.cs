using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Player.Component
{
    [RequireComponent(typeof(PlayerMovableAreaComponent))]
    public class PlayerMoveComponent : MoveComponent
    {
        private PlayerMovableAreaComponent _playerMovableAreaComponent;
        
        public override void Move(Vector2 direction, float speed)
        {
            base.Move(direction, speed);

            transform.position = HandlePlayerPosition(transform.position);
        }
        
        private void Start()
        {
            _playerMovableAreaComponent = GetComponent<PlayerMovableAreaComponent>();
        }

        private Vector2 HandlePlayerPosition(Vector2 position)
        {
            Vector2 movableBottomLeft = _playerMovableAreaComponent.MovableBottomLeft;
            Vector2 movableTopRight = _playerMovableAreaComponent.MovableTopRight;
            
            position.x = Mathf.Clamp(position.x, movableBottomLeft.x, movableTopRight.x);
            position.y = Mathf.Clamp(position.y, movableBottomLeft.y, movableTopRight.y);
            
            if (position.x <= movableBottomLeft.x)
            {
                position.x = movableTopRight.x - Mathf.Epsilon;
            } else if (position.x >= movableTopRight.x)
            {
                position.x = movableBottomLeft.x + Mathf.Epsilon;
            }
            
            return position;
        }
    }
}
