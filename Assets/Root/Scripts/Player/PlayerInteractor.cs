using System;
using UnityEngine;

namespace Root
{
    public class PlayerInteractor : MonoBehaviour
    {
        public event Action<IInteractable> OnInteractableChange;
        
        public event Action<IInteractable> OnInteract;

        public event Action<Hint> OnHint;
        
        private InteractionHandler _interactionHandler;
        
        private Interactable _interactable;

        [SerializeField] private float _interactionDistance;
        
        
        private void Awake()
        {
            _interactionHandler = GetComponentInChildren<InteractionHandler>();
            
            _interactionHandler.InteractionDistance = _interactionDistance;
        }

        private void Update()
        {
            _interactable = _interactionHandler.DetectInteractable();
            
            OnInteractableChange?.Invoke(_interactable);
            
            if (!_interactable) return;

            if (Input.GetKeyDown(KeyCode.E))
            {  
                OnInteract?.Invoke(_interactable);
                
                _interactable.Interact();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Hint"))
                OnHint?.Invoke(other.GetComponent<Hint>());
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log(other.tag);
            
            
            if (other.gameObject.CompareTag("Hint"))
                OnHint?.Invoke(null);
        }
    }
}