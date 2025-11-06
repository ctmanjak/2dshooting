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
    }
}
