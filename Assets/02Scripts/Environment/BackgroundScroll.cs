using UnityEngine;

namespace _02Scripts.Environment
{
    public class BackgroundScroll : MonoBehaviour
    {
        private Renderer _renderer;
    
        private readonly Vector2 _direction = Vector2.up;

        public float ScrollSpeed = 1f;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            _renderer.material.mainTextureOffset += _direction * (ScrollSpeed * Time.deltaTime);
        }
    }
}
