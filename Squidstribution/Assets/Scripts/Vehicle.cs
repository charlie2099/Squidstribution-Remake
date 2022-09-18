using System;
using UnityEngine;

public class Vehicle : MonoBehaviour, IDamageable, IPickupable
{
    public Action<float, float> OnDamageReceived;
    public float CurrentHealth { get; set; }

    private float _maxHealth;
    /*private float _timePassed; */

    private void Start()
    {
        /*_timePassed = 1.0f;*/
        _maxHealth = 100;
        CurrentHealth = _maxHealth;
    }

    private void Update()
    {
        /*if (Time.time > _timePassed)
        {
            TakeDamage(25);
            _timePassed = Time.time + 1.0f;
        }*/
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
        OnDamageReceived?.Invoke(CurrentHealth, _maxHealth);
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
