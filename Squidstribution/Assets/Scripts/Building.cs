using System;
using UnityEngine;

[Serializable]
public struct BuildingStats
{
    public float maxHealth;
    public float karma;
}

public class Building : MonoBehaviour, IDamageable
{
    // Events
    public Action<float, float> OnDamageReceived;
    public Action<BuildingStats> OnDestroyed;
    
    public float CurrentHealth { get; set; }
    [SerializeField] private BuildingStats stats;
    
    private void Start()
    {
        CurrentHealth = stats.maxHealth;
    }
    
    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        
        if (CurrentHealth <= 0)
        {
            OnDestroyed?.Invoke(stats);
            Destroy(gameObject);
        }
        OnDamageReceived?.Invoke(CurrentHealth, stats.maxHealth);
    }
}
