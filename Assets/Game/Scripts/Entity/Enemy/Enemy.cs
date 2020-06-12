using System;
using UnityEngine;

namespace RPG.Game.Entity
{
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : MonoBehaviour, IDeath
    {
        public event Action OnDeathEvent;

        [SerializeField] private EnemyAnimation enemyAnimation;

        private Collider2D collider;
        private SpriteRenderer sprite;

        // Start is called before the first frame update
        public void Start()
        {
            collider = GetComponent<Collider2D>();
            sprite = GetComponentInChildren<SpriteRenderer>();
            sprite.enabled = false;
        }

        void IDeath.OnDeath()
        {
            collider.enabled = false;
            OnDeathEvent?.Invoke();
            GameManager.Current.ScoreManager.AddScore(15);
            GameManager.Current.Death(this);
        }

        public void Destroy()
        {
            sprite.enabled = false;
        }

        public void ResetEnemy()
        {
            collider.enabled = true;
            sprite.enabled = true;
            enemyAnimation.ResetAnimation();
        }
    }
}
