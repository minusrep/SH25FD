using UnityEngine;

namespace Root
{
    public class HealthPack : Interactable
    {
        public float HealthRestoreAmount => _healthRestoreAmount;
        
        [SerializeField] private float _healthRestoreAmount;
        
        public override void Interact()
        {
            Destroy(gameObject);            
        }
    }
}