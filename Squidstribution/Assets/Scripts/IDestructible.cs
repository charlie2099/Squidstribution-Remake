public interface IDestructible
{
    public int CurrentHealth { get; set; }
    public void HitPoints(float health);
    public void ApplyDamage(float damage);
    public void OnDestruction();
}
