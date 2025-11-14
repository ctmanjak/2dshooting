using UnityEngine;

namespace _02Scripts.Environment
{
    [RequireComponent(typeof(Renderer))]
    public class BackgroundScroll : MonoBehaviour
    {
        private Material _material;
    
        private readonly Vector2 _direction = Vector2.up;

        public float ScrollSpeed = 1f;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
        }

        private void Update()
        {
            _material.mainTextureOffset += _direction * (ScrollSpeed * Time.deltaTime);
        }
    }
}
