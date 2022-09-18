using System;

public interface IDamageable 
{
    public float CurrentHealth { set; get; }
    public void TakeDamage(float damage);
}
