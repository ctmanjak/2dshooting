using _02Scripts.Util;
using UnityEngine;

namespace _02Scripts.Player.Component
{
    public class PlayerSkillComponent : MonoBehaviour
    {
        public Camera MainCamera;
        
        public GameObject MinePrefab;

        private Rect _cameraRect;

        public float Duration = 3f;
        public float Interval = 0.1f;

        private float _lastActivateTime;
        private float _lastIntervalTime;
        
        private void Start()
        {
            if (MainCamera == null) MainCamera = Camera.main;
            if (MainCamera == null) return;
            
            _cameraRect = CameraUtil.GetCameraWorldRect(MainCamera);

            _lastActivateTime = Time.time - Duration;
        }

        private void Update()
        {
            float currentTime = Time.time;

            if (currentTime - _lastActivateTime > Duration) return;
            if (currentTime - _lastIntervalTime < Interval) return;

            if (!MinePrefab) return;
            
            Instantiate(MinePrefab, GetRandomPosition(), Quaternion.identity);
            
            _lastIntervalTime = currentTime;
        }

        public void Activate()
        {
            if (Time.time - _lastActivateTime <= Duration) return;
            
            _lastActivateTime = Time.time;
            _lastIntervalTime = Time.time - Interval;
        }

        private Vector2 GetRandomPosition()
        {
            return new Vector2(
                Random.Range(_cameraRect.xMin, _cameraRect.xMax),
                Random.Range(_cameraRect.yMin, _cameraRect.yMax)
            );
        }
    }
}