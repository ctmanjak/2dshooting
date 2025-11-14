using _02Scripts.Common.Component.AI.Move;
using UnityEngine;

namespace _02Scripts.Pet
{
    [RequireComponent(typeof(PetMoveAIComponent))]
    public class PetEntity : MonoBehaviour
    {
        private PetMoveAIComponent _petMoveAIComponent;

        private void Awake()
        {
            _petMoveAIComponent = GetComponent<PetMoveAIComponent>();
        }

        public void Init(GameObject target)
        {
            _petMoveAIComponent.SetTarget(target);
        }

        public GameObject FollowAnchor()
        {
            return gameObject;
        }
    }
}