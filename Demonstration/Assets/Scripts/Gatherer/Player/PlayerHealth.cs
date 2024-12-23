using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public event Action OnDie;

    [Tooltip("Текущее количество здоровья персонажа")]
    [field: SerializeField] public float Health { get; private set; }
    [Tooltip("Максимальное количество здоровья персонажа")]
    [field: SerializeField] public float MaxHealth { get; private set; }
    [Tooltip("Статус неуязвимости")]
    [SerializeField] private bool _invulnerable;
    [Tooltip("Событие - получение урона")]
    public event Action<float, float> OnHealthChange;
    [Tooltip("Событие - лечение")]
    public event Action<float, float> OnAddHealth;


    private void Start() {
        OnHealthChange?.Invoke(Health, MaxHealth);
    }

    public void TakeDamage(float danageValue) {
        if (!_invulnerable) {
            Health -= danageValue;
            Health = Mathf.Max(Health, 0);
            OnHealthChange?.Invoke(Health, MaxHealth);

            if (Health == 0) Die();

            _invulnerable = true;
            Invoke(nameof(StopInvulnerable), 1f);
        }
    }

    private void StopInvulnerable() {
        _invulnerable = false;
    }

    public void AddHealth(int healthValue) {
        Health += healthValue;
        Health = Mathf.Min(Health, MaxHealth);

        OnAddHealth?.Invoke(Health, MaxHealth);
    }

    private void Die() {
        Debug.Log("Die");
        OnDie?.Invoke();
    }

    public void ResetHealth() {
        Health = 5;
        OnHealthChange?.Invoke(Health, MaxHealth);
    }
}
