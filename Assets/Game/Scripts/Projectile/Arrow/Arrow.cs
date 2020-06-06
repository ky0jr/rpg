using UnityEngine;

namespace RPG.Game.Projectile
{
    public sealed class Arrow : ProjectileBase
    {
        private float speed = 10f;
        public override void Reset()
        {
            rb.velocity = Vector2.zero;
        }

        public override void Launch(Vector2 direction, Vector3 position)
        {
            rb.velocity = direction * speed;
            transform.position = position;
        }

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            
            if (col.CompareTag("Enemy"))
            {
                base.OnTriggerEnter2D(col);
            }
            else if (col.CompareTag("Environment"))
            {
                Destroy(gameObject);
            }
        }
    }
}
