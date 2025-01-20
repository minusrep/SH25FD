using System;
using UnityEngine;

namespace Root
{
    [Serializable]
    public class Health
    {
        public event Action OnDie;
        
        public event Action OnChange;

        public float Progress => Current / Max;
        
        public float Current
        {
            get => _current;
            
            private set
            {
                value = value < 0 ? 0 : value;
                
                value = value > _max ? _max : value;
                
                _current = value;
                
                OnChange?.Invoke();
                
                OnDie?.Invoke();
            }
        }
        
        public float Max => _max;
        
        [SerializeField] private float _current;
        
        [SerializeField] private float _max;

        public void TakeDamage(float damage, Action callback = null)
        {
            Current -= damage;
            
            callback?.Invoke();
        }
    }
}