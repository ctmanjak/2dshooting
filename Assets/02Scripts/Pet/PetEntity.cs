using _02Scripts.Common.Component.AI.Move;
using UnityEngine;

namespace _02Scripts.Pet
{
    [RequireComponent(typeof(PetMoveAIComponent))]
    public class PetEntity : MonoBehaviour
    {
        private PetMoveAIComponent _petMoveAIComponent;

        public void Init(GameObject target)
        {
            _petMoveAIComponent = GetComponent<PetMoveAIComponent>();
            _petMoveAIComponent.SetTarget(target);
        }
    }
}