using System;
using UnityEngine;

namespace RPG.Game.Entity
{
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        public static event Action<Vector3> OnDrop;
        
        public event Action OnDamageEvent;

        public event Action OnDeathEvent;

        [SerializeField] private EnemyAnimation enemyAnimation;

        private Collider2D collider;

        // Start is called before the first frame update
        void Start()
        {
            collider = GetComponent<Collider2D>();
            collider.isTrigger = true;
            enemyAnimation.Initialize();
        }

        public void OnDamage(int damage)
        {
            OnDamageEvent?.Invoke();
            OnDeath();
        }

        public void OnDeath()
        {
            collider.enabled = false;
            OnDeathEvent?.Invoke();
            GameManager.Current.ScoreManager.AddScore(15);
        }

        public void Destroy()
        {
            OnDrop?.Invoke(transform.position);
            Destroy(gameObject);
        }
    }
}
