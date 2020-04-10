using System;
using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game.Player
{
    public abstract class PlayerAttack: MonoBehaviour, IAttack
    {
        private void Start()
        {
            GetComponent<PlayerInput>().OnFire += Attack;
        }

        public event Action OnAttackEvent;
        public int Damage { get;   }
        public int AttackRange { get; }
        public int AttackSpeed { get; }

        public virtual void Attack()
        {
            OnAttackEvent?.Invoke();
        }

        public void DealDamage()
        {
            
        }
    }
}