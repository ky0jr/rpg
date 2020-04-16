using System;
using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game.Player
{
    public class Player : MonoBehaviour, IHealth, IDamageable
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }
        public event Action OnDamageEvent;
        public event Action OnDeathEvent;
        public void OnDamage(int damage)
        {
            OnDamageEvent?.Invoke();
            CurrentHealth -= damage;
            
            if (CurrentHealth < 0)
            {
                OnDeath();
            }
        }

        public void OnDeath()
        {
            OnDeathEvent?.Invoke();
        }
    }
}
