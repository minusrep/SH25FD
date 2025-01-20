using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Root
{
    public class UIStartMenu : MonoBehaviour
    {
        [SerializeField] private Button _startButton;

        [SerializeField] private Button _exitButton;

        [SerializeField] private int _sceneToLoad;
        
        private void Awake()
        {
            _startButton.onClick.AddListener(() => SceneManager.LoadScene(_sceneToLoad));
            
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}