using UnityEngine;

namespace Root
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        public static int InteractableLayer => LayerMask.GetMask("Interactable");

        public string Description => _description;
        
        [SerializeField][TextArea] private string _description;

        public abstract void Interact();
    }
}