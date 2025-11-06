using _02Scripts.Common.Enum;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent), typeof(EquipmentComponent))]
    public class AttackComponent : MonoBehaviour
    {
        private StatComponent _statComponent;
        private EquipmentComponent _equipmentComponent;

        private void Start()
        {
            _statComponent = GetComponent<StatComponent>();
            _equipmentComponent = GetComponent<EquipmentComponent>();
        }

        public void Fire(Vector2 direction)
        {
            foreach (var gun in _equipmentComponent.Guns)
            {
                gun.Fire(_statComponent.Damage, direction);
            }
        }
    }
}