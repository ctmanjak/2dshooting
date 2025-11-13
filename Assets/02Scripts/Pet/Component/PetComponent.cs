using System.Collections.Generic;
using UnityEngine;

namespace _02Scripts.Pet.Component
{
    public class PetComponent : MonoBehaviour
    {
        public PetEntity PetPrefab;
        private readonly List<PetEntity> _pets = new();

        public int InitialPetNumber = 3; 
        public float Gap = 1f;

        public void Start()
        {
            for (int i = 0; i < InitialPetNumber; i++) AddPet();
        }

        private void AddPet()
        {
            PetEntity pet = Instantiate(PetPrefab, transform.position + Vector3.right * Gap * (_pets.Count + 1), Quaternion.identity);
            
            GameObject previousTarget = gameObject;
            if (_pets.Count > 0) previousTarget = _pets[^1].gameObject;
            pet.Init(previousTarget);
            
            _pets.Add(pet);
        }
    }
}