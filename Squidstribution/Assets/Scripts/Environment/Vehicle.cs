using System;
using Interfaces;
using UnityEngine;

namespace Environment
{
    public class Vehicle : MonoBehaviour, IDamageable, IDestructible, IPickupable
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

        public void Pickup(GameObject obj)
        {
            /*GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<MeshCollider>().enabled = false;
        transform.position = obj.transform.position + Vector3.up * 7;
        transform.SetParent(obj.transform);*/
        }

        public void Drop()
        {
            /*GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<MeshCollider>().enabled = false;
        transform.SetParent(null);*/
        }
    }
}
