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

        protected virtual Vector2 GetTargetDirection()
        {
            Vector2 direction = Target ?
                (Target.transform.position - transform.position).normalized : Vector2.down;

            return direction;
        }
    }
}
