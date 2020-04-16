﻿using UnityEngine;

namespace RPG.Game.Projectile
{
    public abstract class Projectile : MonoBehaviour
    {
        protected Rigidbody2D rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public abstract void Reset();

        public abstract void Launch(Vector2 direction, Vector3 position);
    }
}
