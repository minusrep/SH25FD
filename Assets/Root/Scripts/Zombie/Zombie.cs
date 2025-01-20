using UnityEngine;

namespace Root
{
    [RequireComponent(typeof(ZombieMovement))]
    
    [RequireComponent(typeof(ZombieDamageHandler))]
    
    [RequireComponent(typeof(ZombieCombat))]
    
    [RequireComponent(typeof(DetectionHandler))]
    public class Zombie : MonoBehaviour
    {
        public ZombieMovement Movement { get; private set; }
        
        public ZombieDamageHandler DamageHandler { get; private set; }
        
        public ZombieCombat Combat { get; private set; }
        
        private void Awake()
        {
            Movement = GetComponent<ZombieMovement>();
            
            DamageHandler = GetComponent<ZombieDamageHandler>();
            
            Combat = GetComponent<ZombieCombat>();
            
            DamageHandler.OnDead += Movement.Disable;
        }
        
        private void Update()
        {
        }
    }
}