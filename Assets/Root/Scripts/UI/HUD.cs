using Root;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private Health _health;
    
    [SerializeField] private Image _healthBar;
     
    [SerializeField] private PlayerDamageHandler _playerDamageHandler;
    
    private void Awake()
    {
        _health = _playerDamageHandler.Health;

        var health = 1f - _health.Progress;
        
        _health.OnChange += () => SetHealth(health);
        
        SetHealth(health);
    }

    private void SetHealth(float value)
    {
        var color = Color.white;

        color.a = value;

        _healthBar.color = color;
    }
}
