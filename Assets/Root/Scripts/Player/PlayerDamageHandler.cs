using UnityEngine;

namespace Root
{
    public class PlayerDamageHandler : MonoBehaviour
    {
        private const string AttackTag = "Attack";
        public Health Health => _health;
        
        [SerializeField] private Health _health;

        private void OnEnable()
        {
            _health.OnDie += Die;
        }

        private void OnDisable()
        {
            _health.OnDie -= Die;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(AttackTag)) return;

            _health.TakeDamage(other.GetComponent<Attack>().Damage);
        }

        private void Die()
        {
            gameObject.SetActive(false);
            
            Cursor.visible = true;
            
            Cursor.lockState = CursorLockMode.None;
        }
    }
}