using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class TargetComponent : MonoBehaviour
    {
        private GameObject _target;

        public Vector2 GetTargetDirection()
        {
            return IsTargetExist()
                ? (_target.transform.position - transform.position).normalized
                : Vector2.down;
        }

        public Vector2 GetTargetPosition()
        {
            return IsTargetExist()
                ? _target.transform.position
                : Vector2.zero;
        }

        public bool IsTargetExist()
        {
            return _target;
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }

        public GameObject GetTarget()
        {
            return _target;
        }

        public T GetTargetComponent<T>()
        {
            return IsTargetExist()
                ? _target.GetComponent<T>()
                : default;
        }
    }
}