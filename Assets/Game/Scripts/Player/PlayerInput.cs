using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game.Player
{
    internal class PlayerInput: MonoBehaviour
    {
        public event System.Action OnFire;
        
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private bool CanInput = true;

        private void Start()
        {
            GetComponent<IDamageable>().OnDeathEvent += () => { CanInput = false; };
        }

        private void Update()
        {
            if(!CanInput)
                return;
            
            if (Input.GetButtonDown("Fire1"))
            {
                OnFire?.Invoke();
            }
            
            Vertical = Input.GetAxisRaw("Vertical");
            
            Horizontal = Input.GetAxisRaw("Horizontal");
        }
    }
}