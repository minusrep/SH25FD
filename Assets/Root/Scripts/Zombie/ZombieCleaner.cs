using UnityEngine;

namespace Root
{
    public class ZombieCleaner : MonoBehaviour
    {
        private bool _readyToDestroy;

        private ZombieDamageHandler _damageHandler;

        private DetectionHandler _detectionHandler;

        [SerializeField] private float _cleanDistance;
        
        private void Awake()
        {
            _damageHandler = GetComponent<ZombieDamageHandler>();
            
            _detectionHandler = GetComponent<DetectionHandler>();
            
            _damageHandler.OnDead += () => _readyToDestroy = true;
        }

        private void Update()
        {
            if (!_readyToDestroy) return;
            
            var detected = _detectionHandler.DetectAround(_cleanDistance, transform.position, Player.Layer);
            
            if (!detected) Destroy(gameObject);
        }

        private void ReadyToDestroy()
        {
            
        }
    }
}