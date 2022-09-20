using System;
using Interfaces;
using UnityEngine;

namespace Environment
{
    public class Tree : MonoBehaviour, IDamageable
    {
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
                Destroy(gameObject);
            }
        }
    }
}
