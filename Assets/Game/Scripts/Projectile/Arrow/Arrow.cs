using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Game.Projectile
{
    public sealed class Arrow : Projectile
    {
        public override void Reset()
        {
            rb.velocity = Vector2.zero;
        }

        public override void Launch(Vector2 direction, Vector3 position)
        {
            
        }
    }
}
