using System;
using UnityEngine;

public class Vehicle : MonoBehaviour, IDamageable, IPickupable
{
    // Events
    public Action<float, float> OnDamageReceived;
    public Action OnDestroyed;
    
    [SerializeField] private float maxHealth;
    public float CurrentHealth { get; set; }

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
