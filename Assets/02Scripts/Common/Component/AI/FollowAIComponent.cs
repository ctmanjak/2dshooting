using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    public class FollowAIComponent : AIComponent
    {
        private GameObject _target;

        protected override void Init()
        {
            base.Init();
            _target = GameObject.FindWithTag("Player");
        }

        protected override Vector2 GetMoveDirection()
        {
            Vector2 direction = _target ?
                (_target.transform.position - transform.position).normalized : Vector2.down;

            return direction;
        }
    }
}
