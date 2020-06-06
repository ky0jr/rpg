using UnityEngine;

namespace RPG.Game.Projectile
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ProjectileBase : MonoBehaviour
    {
        protected Rigidbody2D rb;
        private Collider2D collider;
        public event System.Action<Transform> OnHitEvent;
        
        // Start is called before the first frame update
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            collider = GetComponent<Collider2D>();
            collider.isTrigger = true;
        }

        public abstract void Reset();

        public abstract void Launch(Vector2 direction, Vector3 position);

        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            OnHitEvent?.Invoke(col.transform);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            OnHitEvent = null;
        }

        private void OnDisable()
        {
            OnDestroy();
        }
    }
}
