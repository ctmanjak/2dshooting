using _02Scripts.Player.Enum;
using UnityEngine;

namespace _02Scripts.Common.Component
{
    [RequireComponent(typeof(StatComponent), typeof(EquipmentComponent))]
    public class AttackComponent : MonoBehaviour
    {
        private StatComponent _statComponent;
        private EquipmentComponent _equipmentComponent;

        private EFireType _fireType;
        private Vector2 _attackDirection;

        private void Start()
        {
            _statComponent = GetComponent<StatComponent>();
            _equipmentComponent = GetComponent<EquipmentComponent>();
        }

        private void Update()
        {
            if (_fireType == EFireType.Auto) Fire();
        }

        public void Fire()
        {
            foreach (var gun in _equipmentComponent.Guns)
            {
                gun.Fire(_statComponent.Damage, _attackDirection);
            }
        }

        public void SetFireType(EFireType fireType)
        {
            _fireType = fireType;
        }

        public void SetAttackDirection(Vector2 direction)
        {
            _attackDirection = direction;
        }
    }
}