using System;
using System.Collections;
using Environment;
using Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Effects
{
    public class ShakeOnImpactEffect : MonoBehaviour
    {
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float shakeMultiplier = 0.05f;
        
        //private Building _building; // TODO: Change to static objects
        private IDamageable _damageable;
        private Vector3 _lastPosition;
        private bool _isShaking;

        private void Awake()
        {
            if (GetComponent<IDamageable>() == null)
            {
                Debug.LogError("GameObject does not contain a IDamageable component!", this);
            }
            _damageable = GetComponent<IDamageable>();
        }

        private void OnEnable()
        {
            _damageable.OnDamaged += InitiateShake;
        }

        private void OnDisable()
        {
            _damageable.OnDamaged -= InitiateShake;
        }

        private void Update()
        {
            if (_isShaking)
            {
                var x = Random.insideUnitSphere.normalized.x * shakeMultiplier;
                var z = Random.insideUnitSphere.normalized.z * shakeMultiplier;
                //_building.transform.position += new Vector3(x, 0, z);
                transform.position += new Vector3(x, 0, z);
            }
        }

        private void InitiateShake()
        {
            StartCoroutine(Shake());
        }

        private IEnumerator Shake()
        {
            _lastPosition = transform.position;
            _isShaking = true;
            yield return new WaitForSeconds(duration);
            _isShaking = false;
            transform.position = _lastPosition;
        }
    }
}
