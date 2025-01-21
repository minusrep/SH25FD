using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Root
{
    public class ZombieCombat : MonoBehaviour
    {
        private const string CharacterLayer = "Character";
        
        private const string AttackingAnimation = "Attacking";
        
        private NavMeshAgent _navMeshAgent;
            
        private Animator _animator;
        
        private DetectionHandler _detectionHandler;

        private Attack _attack;
        
        [SerializeField] private float _damage;
        
        [SerializeField] private float _attackDistance;

        [SerializeField] private Color _gizmosColor;

        private void OnDrawGizmos()
        {
            Gizmos.color = _gizmosColor;
            
            Gizmos.DrawSphere(transform.position + Vector3.up, _attackDistance);
        }
        
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            
            _animator = GetComponentInChildren<Animator>();

            _attack = GetComponentInChildren<Attack>();
            
            _detectionHandler = GetComponent<DetectionHandler>();
            
            _navMeshAgent.stoppingDistance = _attackDistance;

            _attack.Damage = _damage;
        }

        private void Update()
        {
            var detected = _detectionHandler.DetectAround(_attackDistance, transform.position, Player.Layer);
            
            _animator.SetBool(AttackingAnimation, detected);
            
            _attack.Active = detected;
        }
    }
}