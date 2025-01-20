using UnityEngine;

namespace Root
{
    public class PlayerDamageHandler : MonoBehaviour
    {
        public Health Health => _health;
        
        [SerializeField] private Health _health;
    }
}