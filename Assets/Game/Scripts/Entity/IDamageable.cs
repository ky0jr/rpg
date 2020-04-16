namespace RPG.Game.Entity
{
    public interface IDamageable
    {
        event System.Action OnDamageEvent;

        event System.Action OnDeathEvent;

        void OnDamage(int damage);

        void OnDeath();
    }
}