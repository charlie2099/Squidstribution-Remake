using System;
using Interfaces;
using UnityEngine;

namespace Environment
{
    public class Building : MonoBehaviour, IDamageable, IDestructible
    {
        public Action OnDestroyed { get; set; } // IDestructible
        public Action<float, float> OnDamageReceived;
    
        public float CurrentHealth { get; set; } // IDamageable
        [SerializeField] private float maxHealth;

        private void Start()
        {
            CurrentHealth = maxHealth;
        }
    
        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
        
            if (CurrentHealth <= 0)
            {
                OnDestroyed?.Invoke();
                Destroy(gameObject);
            }
            OnDamageReceived?.Invoke(CurrentHealth, maxHealth);
        }
    }
}
