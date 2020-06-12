using UnityEngine;

namespace RPG.Game.Player
{
    public class Player : MonoBehaviour
    {

        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private PlayerAttack playerAttack;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private PlayerMovement playerMovement;

        public void Initialize()
        {
            playerInput.Initialize();
            playerAnimation.Initialize();
            playerMovement.Initialize();
            playerAttack.Initialize();
        }
    }
}
