using RPG.Game.Entity;
using UnityEngine;

namespace RPG.Game
{
    public class DropManager: MonoBehaviour
    {
        [SerializeField] 
        private Collectible.Collectible[] prefab = new Collectible.Collectible[2];

        public void Initialize()
        {
            Enemy.OnDrop += Drop;
        }

        private void Drop(Vector3 position)
        {
            float random = Random.Range(0f, 1000f);

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