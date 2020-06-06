using System;
using System.Collections.Generic;
using RPG.Game.Entity;
using RPG.Game.Projectile;
using UnityEngine;

namespace RPG.Game.Player
{
    public class PlayerAttack: MonoBehaviour, IAttack
    {
        #region Prefab

        [SerializeField]
        private ProjectileBase arrowPrefab;

        #endregion
        
        public event Action OnAttackEvent;

        [SerializeField] 
        private Transform attackPoint;

        [SerializeField] 
        private AudioSource audio;

        private Facing facing = Facing.Front;
        
        private Dictionary<int, Vector3> attackPoints;

        private Dictionary<int, Vector3> projectileRotation;

        public void Initialize()
        {
            attackPoints = new Dictionary<int, Vector3>();
            attackPoints[1] = new Vector3(0, -0.7f);
            attackPoints[2] = new Vector3(0, 0.6f);
            attackPoints[3] = new Vector3(-0.6f, -0.2f);
            attackPoints[4] = new Vector3(0.6f, -0.2f);
            
            attackPoint.localPosition = attackPoints[1];
            
            projectileRotation = new Dictionary<int, Vector3>();
            
            projectileRotation[1] = new Vector3(0, 0, 180);
            projectileRotation[2] = new Vector3(0, 0, 0);
            projectileRotation[3] = new Vector3(0, 0, 90);
            projectileRotation[4] = new Vector3(0, 0, -90);
            
            GetComponent<PlayerAnimation>().OnFacingChange += SetAttackPoint;
        }

        public void Attack()
        {
            OnAttackEvent?.Invoke();
            ProjectileBase arrow = Instantiate(arrowPrefab);
            arrow.Reset();
            arrow.transform.localEulerAngles = projectileRotation[(int)facing];
            Vector2 dir;
            switch (facing)
            {
                case Facing.Front:
                    dir = Vector2.down;
                    break;
                case Facing.Back:
                    dir = Vector2.up;
                    break;
                case Facing.Left:
                    dir = Vector2.left;
                    break;
                case Facing.Right:
                    dir = Vector2.right;
                    break;
                default:
                    dir = Vector2.down;
                    break;
            }

            arrow.OnHitEvent += DealDamage;
            arrow.Launch(dir, attackPoint.position);
            audio.Play();
        }

        private void SetAttackPoint(int facing)
        {
            this.facing = (Facing)facing;
            attackPoint.localPosition = attackPoints[facing];
        }

        private void DealDamage(Transform target)
        {
            HitManager.OnDamage(target);
        }
    }
}