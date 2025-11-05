using _02Scripts.Common;
using UnityEngine;

namespace _02Scripts.Player
{
    [RequireComponent(typeof(HealthComponent), typeof(StatComponent))]
    public class PlayerEntity : MonoBehaviour
    {
        private StatComponent _statComponent;
        private HealthComponent _healthComponent;

        public void Start()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _statComponent = GetComponent<StatComponent>();
        }
    }
}