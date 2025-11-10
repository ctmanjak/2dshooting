using UnityEngine;

namespace _02Scripts.Common.Component.AI.Condition
{
    public class DelayAICondition : MonoBehaviour, IAICondition
    {
        private float _timer;
        public float DelayTime = 2f;

        private void Start()
        {
            _timer = Time.time;
        }

        public bool CanAct()
        {
            return Time.time - _timer >= DelayTime;
        }
    }
}