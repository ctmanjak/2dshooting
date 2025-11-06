using UnityEngine;

namespace _02Scripts.Common.Component.AI
{
    public abstract class TargetAIComponent : AIComponent
    {
        protected GameObject Target;

        protected override void Init()
        {
            base.Init();
            Target = GameObject.FindWithTag("Player");
        }

        protected Vector2 GetTargetDirection()
        {
            Vector2 direction = Target ?
                (Target.transform.position - transform.position).normalized : Vector2.down;

            return direction;
        }

        protected override Vector2 GetAttackDirection()
        {
            return GetTargetDirection();
        }

        protected override Vector2 GetMoveDirection()
        {
            return GetTargetDirection();
        }
    }
}
