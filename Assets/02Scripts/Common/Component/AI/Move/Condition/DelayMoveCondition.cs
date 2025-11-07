using System;
using UnityEngine;

namespace _02Scripts.Common.Component.AI.Move.Condition
{
    public class DelayMoveCondition : MonoBehaviour, IMoveCondition
    {
        private float _timer;
        public float DelayTime = 2f;

        private void Start()
        {
            _timer = Time.time;
        }

        public bool CanMove()
        {
            return Time.time - _timer >= DelayTime;
        }
    }
}