using UnityEngine;

namespace _02Scripts.Common.Component
{
    public class TargetComponent : MonoBehaviour
    {
        private GameObject _target;

        public Vector2 GetTargetDirection()
        {
            Vector2 direction = _target ?
                (_target.transform.position - transform.position).normalized : Vector2.down;

            return direction;
        }

        public Vector2 GetTargetPosition()
        {
            return _target.transform.position;
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
            return _target.GetComponent<T>();
        }
    }
}