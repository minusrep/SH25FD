using UnityEngine;
using UnityEngine.AI;

namespace Root
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ZombieMovement : MonoBehaviour
    {
        private const string WalkingAnimation = "Walking";
        
        private DetectionHandler _detectionHandler;
        
        private NavMeshAgent _navMeshAgent;

        private Animator _animator;
        
        [SerializeField] private float _speed;
        
        [SerializeField] private float _detectionRadius;
        
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            
            _detectionHandler = GetComponent<DetectionHandler>();
            
            _animator = GetComponentInChildren<Animator>();
            
            _navMeshAgent.speed = _speed;
        }

        private void Update()
        {
            var detected = _detectionHandler.DetectAround(_detectionRadius, transform.position, Player.Layer);
            
            _animator.SetBool(WalkingAnimation, detected);

            if (!detected) return;
            
            _navMeshAgent.SetDestination(detected.transform.position);
        }

        public void Disable()
        {
            _navMeshAgent.isStopped = true;
        }
    }
}