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
    }
}
