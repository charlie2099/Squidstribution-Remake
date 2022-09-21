using Interfaces;
using UnityEngine;

namespace Effects
{
    public class ExplosionEffect : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab;
    
        private IDestructible _destructible; 

        private void Awake()
        {
            if (GetComponent<IDestructible>() == null)
            {
                Debug.LogError("GameObject does not contain a IDestructible component!", this);
            }
            _destructible = GetComponent<IDestructible>();
        }

        private void OnEnable()
        {
            _destructible.OnDestroyed += PlayExplosionEffect;
        }

        private void OnDisable()
        {
            _destructible.OnDestroyed -= PlayExplosionEffect;
        }

        private void PlayExplosionEffect()
        {
            var explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosionEffect.transform.Rotate(-88.988f, 0, 0);
        }
    }
}
