using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeOnImpact : MonoBehaviour
{
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float shakeMultiplier = 0.05f;
        
    private Vehicle _vehicle;
    private Vector3 _lastPosition;
    private bool _isShaking;

    private void Awake()
    {
        _vehicle = GetComponent<Vehicle>();
    }

    private void OnEnable()
    {
        _vehicle.OnDamageReceived += InitiateShake;
    }

    private void OnDisable()
    {
        _vehicle.OnDamageReceived -= InitiateShake;
    }

    private void Update()
    {
        if (_isShaking)
        {
            var x = Random.insideUnitSphere.normalized.x * shakeMultiplier;
            var z = Random.insideUnitSphere.normalized.z * shakeMultiplier;
            _vehicle.transform.position += new Vector3(x, 0, z);
        }
    }

    private void InitiateShake(float health, float damage)
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        _lastPosition = _vehicle.transform.position;
        _isShaking = true;
        yield return new WaitForSeconds(duration);
        _isShaking = false;
        _vehicle.transform.position = _lastPosition;
    }
}
