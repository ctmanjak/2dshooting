using _02Scripts.Common.Component;
using _02Scripts.Player.Component;
using UnityEngine;

namespace _02Scripts.Player
{
    [RequireComponent(typeof(HealthComponent), typeof(StatComponent), typeof(PlayerInputComponent))]
    [RequireComponent(typeof(AttackComponent))]
    public class PlayerEntity : MonoBehaviour
    {
    }
}