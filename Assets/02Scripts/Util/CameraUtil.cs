using UnityEngine;

namespace _02Scripts.Util
{
    public static class CameraUtil
    {
        public static Rect GetCameraWorldRect(Camera cam)
        {
            float height = cam.orthographicSize * 2f;
            float width = height * cam.aspect;

            Vector3 center = cam.transform.position;

            float left = center.x - width / 2f;
            float bottom = center.y - height / 2f;

            return new Rect(left, bottom, width, height);
        }
    }
}