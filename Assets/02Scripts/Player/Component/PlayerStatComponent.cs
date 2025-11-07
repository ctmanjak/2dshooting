using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Player.Component
{
    public class PlayerStatComponent : StatComponent
    {
        public Vector2 InitialPosition { get; private set; }
        
        public int SpeedChangeAmount = 1;

        private void Start()
        {
            InitialPosition = transform.position;
        }
    }
}