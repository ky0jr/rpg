namespace RPG.Game.Entity
{
    public interface IDeath
    {
        event System.Action OnDeathEvent;

        void OnDeath();
    }
}
