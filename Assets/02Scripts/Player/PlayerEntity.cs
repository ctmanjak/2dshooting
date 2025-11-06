using _02Scripts.Common.Component;
using UnityEngine;

namespace _02Scripts.Player
{
    [RequireComponent(typeof(HealthComponent), typeof(StatComponent), typeof(PlayerInputController))]
    [RequireComponent(typeof(AttackComponent))]
    public class PlayerEntity : MonoBehaviour
    {
    }
}