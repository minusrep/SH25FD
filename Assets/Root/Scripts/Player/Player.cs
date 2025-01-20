using UnityEngine;

namespace Root
{
    [RequireComponent(typeof(PlayerDamageHandler))]
    public class Player : MonoBehaviour
    {
        public static int Layer => LayerMask.GetMask("Character");   
        
        private void Awake()
        {
            
        }

        public void TakeDamage(float damage)
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Works");
        }
    }
}