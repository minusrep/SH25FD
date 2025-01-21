using System;
using UnityEngine;

namespace Root
{
    public class InteractionHandler : MonoBehaviour
    {
        public float InteractionDistance {get; set;}
        
        [SerializeField] private bool _drawGizmos;
        
        [SerializeField] private Color _rayColor;
        
        private void OnDrawGizmos()
        {
            if (!_drawGizmos) return;
            
            Gizmos.color = _rayColor;
            
            Gizmos.DrawRay(transform.position, transform.forward * 10f);
        }

        public Interactable DetectInteractable()
        {
            var raycast = new RaycastHit[1];
            
            Physics.RaycastNonAlloc(transform.position, transform.forward, raycast, InteractionDistance, Interactable.InteractableLayer);

            return raycast[0].collider == null ? null : raycast[0].collider.gameObject.GetComponent<Interactable>();
        }
    }
}