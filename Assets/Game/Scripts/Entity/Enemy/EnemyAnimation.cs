using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RPG.Game.Entity
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimation : MonoBehaviour
    {
        enum EnemyLook
        {
            Front = 1,
            Left,
            Right,
            Back
        }
        
        private static readonly int Death = Animator.StringToHash("death");
        
        private Animator animator;

        private float updateTime = 0f;
        
        [SerializeField]
        private EnemyLook lastLook;

        private bool isUpdating;
        
        // Start is called before the first frame update
        public void Initialize()
        {
            animator = GetComponent<Animator>();
            GetComponent<IDamageable>().OnDeathEvent += () =>
            {
                animator.SetTrigger(Death);
                isUpdating = false;
            };
            lastLook = EnemyLook.Front;
            UpdateAnimation();
            isUpdating = true;
        }

        private void Update()
        {
            if(!isUpdating)
                return;
            
            if (Time.time >= updateTime)
            {
                UpdateAnimation();
            }
        }

        private void UpdateAnimation()
        {
            var look = lastLook;

            while (look == lastLook)
            {
                look = (EnemyLook)Random.Range(0, 4) + 1;
            }

            lastLook = look;
            
            animator.SetTrigger(look.ToString().ToLower());
            
            updateTime = Time.time + Random.Range(2.0f, 5.0f);
        }
    }
}
