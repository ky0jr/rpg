using UnityEngine;

namespace RPG.Game.Collectible
{
    public abstract class Collectible : MonoBehaviour
    {
        private Collider2D collider;

        private void Awake()
        {
            collider = GetComponent<Collider2D>();
            collider.isTrigger = true;
        }
        
        protected abstract void OnTriggerEnter2D(Collider2D other);
    }
}
