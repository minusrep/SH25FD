using UnityEngine;
using UnityEngine.SceneManagement;

namespace Root
{
    public class SceneTransition : Interactable
    {
        [SerializeField] private int _sceneToLoad;
        
        public override void Interact()
        {
            SceneManager.LoadScene(_sceneToLoad);
            
            Cursor.visible = true;
            
            Cursor.lockState = CursorLockMode.None;
        }
    }
}