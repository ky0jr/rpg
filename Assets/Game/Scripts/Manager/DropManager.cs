using System.Collections.Generic;
using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game
{
    public class DropManager: MonoBehaviour
    {
        [SerializeField]
        private Collectible.Collectible[] prefab = new Collectible.Collectible[2];

        public void Initialize(IEnumerable<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                enemy.OnDeathEvent += () => Drop(enemy.transform);
            }
        }

        private void Drop(Transform _transform)
        {
            float random = Random.Range(0f, 1000f);

            Vector3 position = _transform.position;

            if (random < 700)
            {
                Instantiate(prefab[0], position, Quaternion.identity);
            }
            else
            {
                Instantiate(prefab[1], position, Quaternion.identity);
            }
        }
    }
}
