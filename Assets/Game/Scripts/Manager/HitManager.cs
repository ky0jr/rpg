using System.Collections.Generic;
using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game
{
    public static class HitManager
    {
        private static Dictionary<Transform, IDeath> Damageables = new Dictionary<Transform, IDeath>();

        public static void OnDamage(Transform target)
        {
            IDeath death;

            if (Damageables.ContainsKey(target))
            {
                death = Damageables[target];
            }
            else
            {
                death = target.GetComponent<IDeath>();
                Damageables[target] = death;
            }

            death.OnDeath();
        }
    }
}
