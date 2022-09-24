using Interfaces;
using UnityEngine;

namespace Effects
{
    public class DestructionEffect : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab;
    
        private IDamageable _damageable; 

        private void Awake()
        {
            if (GetComponent<IDamageable>() == null)
            {
                Debug.LogError("GameObject does not contain a IDestructible component!", this);
            }
            _damageable = GetComponent<IDamageable>();
        }

        private void OnEnable()
        {
            //_damageable.OnDamaged += PlayDamageEffect;
            _damageable.OnDestroyed += PlayExplosionEffect;
        }

        private void OnDisable()
        {
            //_damageable.OnDamaged -= PlayDamageEffect;
            _damageable.OnDestroyed -= PlayExplosionEffect;
        }

        private void PlayDamageEffect()
        {
            var explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosionEffect.transform.Rotate(-88.988f, 0, 0);
        }

        private void PlayExplosionEffect()
        {
            var explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosionEffect.transform.Rotate(-88.988f, 0, 0);
        }
    }
}
