using System;
using UnityEngine;

namespace DailyChallenges.Day01
{
    public class Health : MonoBehaviour
    {
        public event Action<float> OnHealthChanged;
        public event Action OnDied;
    
        [SerializeField] private float _maxHealth = 100f;
        private float _current;

        public Health(float f)
        {
            _current = f;
        }

        void Awake() => _current = _maxHealth;

        public void TakeDamage(float amount)
        {
            _current = Mathf.Max(0, _current - amount);
            OnHealthChanged?.Invoke(_current);
            if (_current <= 0) OnDied?.Invoke();
        }
    }

    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Health _health;
        void OnEnable() => _health.OnHealthChanged += UpdateBar;
        void OnDisable() => _health.OnHealthChanged -= UpdateBar;
        void UpdateBar(float val) => Debug.Log($"Health: {val}");
    }
    
}
