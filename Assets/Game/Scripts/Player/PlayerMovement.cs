using System;
using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game.Player
{
    public class PlayerMovement: MonoBehaviour
    {
        private Rigidbody2D rb;
        private PlayerInput input;
        private bool attack = false;
        
        [SerializeField]
        private float moveSpeed = 5f;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            input = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            GetComponent<IAttack>().OnAttackEvent += () => { attack = false; };
            input.OnFire += () => { attack = true; };
        }

        private void FixedUpdate()
        {
            if (attack)
            {
                rb.velocity = Vector2.zero;
                return;
            }

            Vector2 input = Math.Abs(this.input.Vertical) > 0
                ? new Vector2(0, this.input.Vertical)
                : new Vector2(this.input.Horizontal, 0);
            rb.velocity = input * moveSpeed;
        }
    }
}