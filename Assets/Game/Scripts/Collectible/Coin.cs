using UnityEngine;

namespace RPG.Game.Collectible
{
    public class Coin : Collectible
    {
        private int score = 10;
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Current.ScoreManager.AddScore(score);
                Destroy(gameObject);
            }
        }
    }
}