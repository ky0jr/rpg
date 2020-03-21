using UnityEngine;

namespace RPG.Game.Player
{
    internal class PlayerInput: MonoBehaviour
    {
        public event System.Action OnFire;
        
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private void Update()
        {
            Vertical = Input.GetAxisRaw("Vertical");

            Horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Fire1"))
            {
                OnFire?.Invoke();
            }
        }
    }
}