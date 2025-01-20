using System;
using System.Linq;
using UnityEngine;

namespace Root
{
    [RequireComponent(typeof(RagdollHandler))]
    public class ZombieDamageHandler : MonoBehaviour
    {
        public event Action OnDead;
        
        private RagdollHandler _ragdollHandler;

        private Animator _animator;

        [SerializeField] private Health _health;

        [Space]
        
        [SerializeField] private float _headDamage;

        [SerializeField] private float _defaultDamage;
        
        private void Awake()
        {
            _ragdollHandler = GetComponent<RagdollHandler>();
         
            _animator = GetComponentInChildren<Animator>();
            
            _ragdollHandler.Init();
            
            _ragdollHandler.ProjectileHandlers.ToList().ForEach(projectileHandler => projectileHandler.OnHit += HandleDamage);

            _health.OnDie += Die;
        }

        private void OnDisable()
        {
            _ragdollHandler.ProjectileHandlers.ToList().ForEach(projectileHandler => projectileHandler.OnHit -= HandleDamage);
        }

        private void HandleDamage(HitType hitType)
        {
            switch (hitType)
            {
                case HitType.Head:
                    Debug.Log($"Head Damage: {_headDamage}");
                    _health.TakeDamage(_headDamage);
                    break;
                case HitType.Default:
                    Debug.Log($"Default Damage: {_defaultDamage}");
                    _health.TakeDamage(_headDamage);
                    break;
            }
        }

        private void Die()
        {
            _ragdollHandler.Enable();

            _animator.enabled = false;
            
            OnDead?.Invoke();
        }
    }
}