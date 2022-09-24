using System;
using Interfaces;
using UnityEngine;

namespace Environment
{
    public class Vehicle : MonoBehaviour, IDamageable, IThrowable
    {
        public event Action OnDamaged;
        public event Action OnDestroyed;

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
            OnDamaged?.Invoke();
        }

        public void Throw()
        {
            
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
