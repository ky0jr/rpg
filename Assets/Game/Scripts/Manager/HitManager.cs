using System.Collections.Generic;
using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game
{
    public static class HitManager
    {
        private static Dictionary<Transform, IDamageable> Damageables = new Dictionary<Transform, IDamageable>();

        public static void OnDamage(Transform target)
        {
            IDamageable damageable;

            if (Damageables.ContainsKey(target))
            {
                damageable = Damageables[target];
            }
            else
            {
                damageable = target.GetComponent<IDamageable>();
                Damageables[target] = damageable;
            }
            
            damageable.OnDamage(1);
        }
    }
}