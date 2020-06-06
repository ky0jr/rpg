namespace RPG.Game.Entity
{
    public interface IAttack
    {
        event System.Action OnAttackEvent;

        void Attack();
    }
}