using System;

namespace Interfaces
{
    public interface IDamageable
    {
        public event Action OnDamaged;
        public event Action OnDestroyed;
        public float CurrentHealth { set; get; }
        public void TakeDamage(float damage);
    }
}
