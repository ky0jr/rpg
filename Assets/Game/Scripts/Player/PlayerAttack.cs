using System;
using System.Collections.Generic;
using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game.Player
{
    public class PlayerAttack: MonoBehaviour, IAttack
    {
        #region Prefab

        [SerializeField]
        private GameObject arrowPrefab;

        #endregion
        
        public event Action OnAttackEvent;

        [SerializeField] 
        private Transform attackPoint;
        
        private Dictionary<int, Vector3> attackPoints;

        private Dictionary<int, Vector3> projectileRotation;

        private void Start()
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
            
        }

        private void SetAttackPoint(int facing)
        {
            attackPoint.localPosition = attackPoints[facing];
        }
    }
}