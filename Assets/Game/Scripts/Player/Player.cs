using System;
using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game.Player
{
    public class Player : MonoBehaviour
    {

        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private PlayerAttack playerAttack;
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private PlayerMovement playerMovement;
        
        private void Start()
        {
            playerInput.Initialize();
            playerMovement.Initialize();
            playerAttack.Initialize();
            playerAnimation.Initialize();
        }
    }
}
