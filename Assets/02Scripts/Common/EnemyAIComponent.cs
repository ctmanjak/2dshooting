using UnityEngine;

namespace _02Scripts.Common
{
    [RequireComponent(typeof(MoveComponent))]
    public class EnemyAIComponent : MonoBehaviour
    {
        private GameObject _target;

        private MoveComponent _moveComponent;

        private void Start()
        {
            _moveComponent = GetComponent<MoveComponent>();
        }

        private void Update()
        {
            Vector2 direction = _target ?
                (_target.transform.position - transform.position).normalized : Vector2.down;
            
            _moveComponent.SetMoveDirection(direction);
        }

        public void SetTarget(GameObject target)
        {
            _target = target;
        }
    }
}
