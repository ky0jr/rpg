namespace RPG.Game.Entity
{
    public class Object: UnityEngine.MonoBehaviour
    {
        public int Id { get; private set; }
        
        public string Name { get; protected set; }

        private void Awake()
        {
            
        }
    }

    public interface IHealth
    {
        int CurrentHealth { get; }
        
        int MaxHealth { get; }
    }

    public interface IMoveSpeed
    {
        int MoveSpeed { get; }
    }

    public interface IAttack
    {
        event System.Action OnAttackEvent;

        void Attack();
    }
}