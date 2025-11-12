using _02Scripts.Common.Component.Stat;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(AttackStatComponent), typeof(EquipmentComponent))]
    public class AttackComponent : MonoBehaviour
    {
        private AttackStatComponent _attackStatComponent;
        private EquipmentComponent _equipmentComponent;

        private void Start()
        {
            _attackStatComponent = GetComponent<AttackStatComponent>();
            _equipmentComponent = GetComponent<EquipmentComponent>();
        }

        public void Fire(Vector2 direction)
        {
            foreach (var gun in _equipmentComponent.Guns)
            {
                gun.Fire(_attackStatComponent.Damage, direction, _attackStatComponent.GetAttackSpeed());
            }
        }
    }
}