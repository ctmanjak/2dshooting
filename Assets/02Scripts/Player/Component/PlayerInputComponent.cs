using _02Scripts.Common.Component;
using _02Scripts.Player.Enum;
using UnityEngine;

namespace _02Scripts.Player.Component
{
    [RequireComponent(typeof(AttackComponent))]
    public class PlayerInputComponent : MonoBehaviour
    {
        private AttackComponent _attackComponent;

        private void Start()
        {
            _attackComponent = GetComponent<AttackComponent>();
            _attackComponent.SetAttackDirection(Vector2.up);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SetFireType(EFireType.Auto);
            } else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SetFireType(EFireType.Manual);
            }
            
            if (Input.GetKey(KeyCode.Space)) _attackComponent.Fire();
        }

        private void SetFireType(EFireType fireType)
        {
            _attackComponent.SetFireType(fireType);
        }
    }
}