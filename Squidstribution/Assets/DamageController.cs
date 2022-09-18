using UnityEngine;
using Random = UnityEngine.Random;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float damage;
    
    private bool _isAttacking;

    private void OnTriggerEnter(Collider other)
    {
        IDamageable hit = other.gameObject.GetComponent<IDamageable>();
        if (hit != null && _isAttacking)
        {
            hit.TakeDamage(Random.Range(damage, damage*2)); // scale damage based on size and attack type
            var moveDir = other.transform.position - transform.position;
            other.gameObject.GetComponent<Rigidbody>().AddForce(moveDir.normalized * 10000f);
        }
    }
    
    #region Animation Events
    private void DoAttack()
    {
        _isAttacking = true;
    }
        
    private void CancelAttack()
    {
        _isAttacking = false;
    }
    #endregion
}
