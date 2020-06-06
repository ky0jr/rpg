using RPG.Game.Manager;
using UnityEngine;

namespace RPG.Game.Player
{
    internal class PlayerInput: MonoBehaviour
    {
        public event System.Action OnFire;

        public float Horizontal { get; private set; } = 0;
        public float Vertical { get; private set; } = 0;

        private bool CanInput = true;

        public void Initialize()
        {
            if (FindObjectOfType<PauseManager>() is PauseManager manager)
            {
                manager.OnPause += Pause;   
            }
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

        private void Pause(bool pause)
        {
            CanInput = !pause;
        }
    }
}