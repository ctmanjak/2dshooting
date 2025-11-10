using UnityEngine;

namespace _02Scripts.Player.Component
{
    public class PlayerMovableAreaComponent : MonoBehaviour
    {
        private Camera _mainCamera;
        
        public Vector2 MovableTopRight;
        public Vector2 MovableBottomLeft;
        
        private void Start()
        {
            if (_mainCamera == null) _mainCamera = Camera.main;
            if (_mainCamera == null) return;

            if (MovableTopRight != Vector2.zero || MovableBottomLeft != Vector2.zero) return;
            MovableTopRight = _mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, _mainCamera.nearClipPlane));
            MovableBottomLeft = _mainCamera.ViewportToWorldPoint(new Vector3(0, 0, _mainCamera.nearClipPlane));
        }
    }
}