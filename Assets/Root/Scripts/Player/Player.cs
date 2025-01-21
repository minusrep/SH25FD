using System;
using UnityEngine;

namespace Root
{
    [RequireComponent(typeof(PlayerDamageHandler))]
    [RequireComponent(typeof(PlayerInteractor))]
    public class Player : MonoBehaviour
    {
        public static int Layer => LayerMask.GetMask("Character");   

        private PlayerInteractor _interactor;
        
        private PlayerDamageHandler _damageHandler;
        
        private void Awake()
        {
            _damageHandler = GetComponent<PlayerDamageHandler>();
            
            _interactor = GetComponent<PlayerInteractor>();
            
        }

        private void OnEnable()
        {
            _interactor.OnInteract += (interactable) =>
            {
                var healthPack = interactable as HealthPack;

                if (healthPack == null) return;
                
                _damageHandler.Health.TakeHealth(healthPack.HealthRestoreAmount);
            };
        }

        private void OnDisable()
        {
        }
        
        public void TakeDamage(float damage)
        {
            
        }

    }
}