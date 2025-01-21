using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Root
{
    public class UIGameOverScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _root;
        
        [SerializeField] private Button _restartButton;

        [SerializeField] private Button _menuButton;

        [SerializeField] private PlayerDamageHandler _playerDamageHandler;
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
            
            _menuButton.onClick.AddListener(() => SceneManager.LoadScene(0));
            
            _playerDamageHandler.Health.OnDie += () => _root.SetActive(true);
            
            _root.SetActive(false);
        }
    }
}