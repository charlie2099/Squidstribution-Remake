using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float knockbackForce = 1000f;
    
    private bool _duringAttackAnimFrames; 
    private bool _hasInflictedDamage;

    private void OnTriggerStay(Collider other)
    {
        IDamageable hit = other.gameObject.GetComponent<IDamageable>();
        if (hit != null && _duringAttackAnimFrames)
        {
            if (!_hasInflictedDamage)
            {
                hit.TakeDamage(Random.Range(damage, damage*2)); // scale damage based on size and attack type
                _hasInflictedDamage = true;
            }

            // If the attacked object has a rigidbody, apply knockback
            if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                var moveDir = other.transform.position - transform.position;
                other.gameObject.GetComponent<Rigidbody>().AddForce(moveDir.normalized * knockbackForce);
            }
        }
    }

    #region Animation Events
    private void DoAttack()
    {
        _duringAttackAnimFrames = true;
        _hasInflictedDamage = false;
    }
        
    private void CancelAttack()
    {
        _duringAttackAnimFrames = false;
    }
    #endregion
}
