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
    
    public interface IDamageable
    {
        event System.Action OnDamageEvent;

        event System.Action OnDeathEvent;

        event System.Action OnInvulnerableEvent;

        bool IsInvulnerable{ get; }
        
        void OnDamage();

        void OnDeath();
    }

    public interface IAttack
    {
        event System.Action OnAttackEvent;
        
        int Damage { get; }
        
        int AttackRange { get; }
        
        int AttackSpeed { get; }

        void Attack();
    }
}