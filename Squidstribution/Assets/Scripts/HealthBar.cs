using System;
using Environment;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform healthBar;

    private IDamageable _damageable;

    private void Awake()
    {
        if (GetComponent<IDamageable>() == null)
        {
            Debug.LogError("GameObject does not contain a IDamageable component!", this);
        }
        _damageable = GetComponent<IDamageable>();
    }

    private void Start()
    {
        //healthBar.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _damageable.OnDamaged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _damageable.OnDamaged -= UpdateHealthBar;
    }

    private void Update()
    {
        // track player camera rotation
        healthBar.transform.rotation = Camera.main.transform.rotation;
    }

    private void UpdateHealthBar()
    {
        healthBar.gameObject.SetActive(true);
        healthBar.GetComponent<Slider>().maxValue = 250; // TODO: FIX hardcoded value
        healthBar.GetComponent<Slider>().value = _damageable.CurrentHealth;
    }
}