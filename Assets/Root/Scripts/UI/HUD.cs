 using Root;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    private Health _health;
    
    [SerializeField] private Image _healthBar;
     
    [SerializeField] private TextMeshProUGUI _interactableDescription;

    [SerializeField] private TextMeshProUGUI _taskDescription;
    
    [SerializeField] private PlayerDamageHandler _playerDamageHandler;
    
    [SerializeField] private PlayerInteractor _playerInteractor;
    
    private void Awake()
    {
        _health = _playerDamageHandler.Health;

        _health.OnChange += () => SetHealth(1f - _health.Progress);

        _playerInteractor.OnInteractableChange += SetInteractableDescription;

        _playerInteractor.OnHint += (hint) => SetHint(hint ? hint.Description : string.Empty);
        
        SetHealth(1f - _health.Progress);
    }

    private void SetHealth(float value)
    {
        var color = Color.white;

        color.a = value;

        _healthBar.color = color;
    }

    private void SetInteractableDescription(IInteractable interactable)
    {
        var description = interactable != null ? interactable.Description : string.Empty;
        
        _interactableDescription.text = description;
    }

    private void SetHint(string hint)
    {
        _taskDescription.text = hint;
    }
}