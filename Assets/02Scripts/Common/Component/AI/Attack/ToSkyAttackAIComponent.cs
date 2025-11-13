using UnityEngine;

namespace _02Scripts.Common.Component.AI.Attack
{
    public class ToSkyAttackAIComponent : AttackAIComponent
    {
        protected override Vector2 GetAttackDirection()
        {
            return transform.up;
        }
    }
}
