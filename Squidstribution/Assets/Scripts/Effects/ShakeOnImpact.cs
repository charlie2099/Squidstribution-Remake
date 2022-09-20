using System.Collections;
using Environment;
using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(Building))]
    public class ShakeOnImpact : MonoBehaviour
    {
        [SerializeField] private float duration = 0.5f;
        [SerializeField] private float shakeMultiplier = 0.05f;
        
        private Building _building; // TODO: Change to static objects
        private Vector3 _lastPosition;
        private bool _isShaking;

        private void Awake()
        {
            _building = GetComponent<Building>();
        }

        private void OnEnable()
        {
            _building.OnDamageReceived += InitiateShake;
        }

        private void OnDisable()
        {
            _building.OnDamageReceived -= InitiateShake;
        }

        private void Update()
        {
            if (_isShaking)
            {
                var x = Random.insideUnitSphere.normalized.x * shakeMultiplier;
                var z = Random.insideUnitSphere.normalized.z * shakeMultiplier;
                _building.transform.position += new Vector3(x, 0, z);
            }
        }

        private void InitiateShake(float health, float damage)
        {
            StartCoroutine(Shake());
        }

        private IEnumerator Shake()
        {
            _lastPosition = _building.transform.position;
            _isShaking = true;
            yield return new WaitForSeconds(duration);
            _isShaking = false;
            _building.transform.position = _lastPosition;
        }
    }
}
