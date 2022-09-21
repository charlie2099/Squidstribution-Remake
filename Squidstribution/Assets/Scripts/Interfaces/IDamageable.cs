using System;

namespace Interfaces
{
    public interface IDamageable 
    {
        public float CurrentHealth { set; get; }
        public void TakeDamage(float damage);
        public Action OnDamaged { set; get; }
    }
}
