using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIPauseScreen : MonoBehaviour
{
    [SerializeField] private GameObject _root;
    
    [SerializeField] private Button _continueButton;
    
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        _continueButton.onClick.AddListener(Pause);
        
        _exitButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        
        _root.gameObject.SetActive(false);
    }

    private void Pause()
    {
        _root.SetActive(!_root.activeSelf);

        Time.timeScale = _root.activeSelf ? 0 : 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Pause();
    }
}