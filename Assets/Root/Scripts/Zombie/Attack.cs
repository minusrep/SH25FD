using UnityEngine;

namespace Root
{
    public class Attack : MonoBehaviour
    {
        public float Damage { get; set; }

        public bool Active
        {
            set => _collider.enabled = value;
        }
        
        private Collider _collider;
        
        private void Awake() 
            => _collider = GetComponent<Collider>();
    }
}