using UnityEngine;
using UnityEngine.AI;

namespace Root
{
    public class ZombieCombat : MonoBehaviour
    {
        private const string CharacterLayer = "Character";
        
        private const string AttackingAnimation = "Attacking";
        
        private NavMeshAgent _navMeshAgent;
            
        private Animator _animator;
        
        private DetectionHandler _detectionHandler;
        
        [SerializeField] private float _damage;
        
        [SerializeField] private float _attackDistance;

        [SerializeField] private Collider _attackCollider;
        
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

            _detectionHandler = GetComponent<DetectionHandler>();
            
            _navMeshAgent.stoppingDistance = _attackDistance;
        }

        private void Update()
        {
            var detected = _detectionHandler.DetectAround(_attackDistance, transform.position, Player.Layer);
            
            _animator.SetBool(AttackingAnimation, detected);
            
            _attackCollider.enabled = detected;
        }
    }
}