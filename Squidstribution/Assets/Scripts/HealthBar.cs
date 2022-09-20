using System;
using Environment;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform healthBar;

    private Vehicle _vehicle;

    private void Awake()
    {
        _vehicle = transform.GetComponent<Vehicle>();
    }

    private void OnEnable()
    {
        _vehicle.OnDamageReceived += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _vehicle.OnDamageReceived -= UpdateHealthBar;
    }

    private void UpdateHealthBar(float health, float maxHealth)
    {
        //Debug.Log("Health: " + health);
        //Debug.Log("MaxHealth: " + maxHealth);
        healthBar.GetComponent<Slider>().maxValue = maxHealth;
        healthBar.GetComponent<Slider>().value = health;
    }
}