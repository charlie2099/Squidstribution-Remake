using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    
    private Building _building;

    private void Awake()
    {
        _building = GetComponent<Building>();
    }

    private void OnEnable()
    {
        _building.OnDestroyed += PlayExplosionEffect;
    }

    private void OnDisable()
    {
        _building.OnDestroyed -= PlayExplosionEffect;
    }

    private void PlayExplosionEffect(BuildingStats stats)
    {
        var explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosionEffect.transform.Rotate(-88.988f, 0, 0);
    }
}
