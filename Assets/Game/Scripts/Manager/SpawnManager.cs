using System.Collections.Generic;
using RPG.Game.Entity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RPG.Game.Manager
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField]
        private Player.Player player;

        private const int MinDeathTime = 8;

        private const int MaxDeathTime = 13;

        private Dictionary<Enemy, float> currentSpawningEnemies;

        private List<Enemy> spawnedEnemy;

        private List<Enemy> enemies;

        public void Initialize()
        {
            currentSpawningEnemies = new Dictionary<Enemy, float>();
            spawnedEnemy = new List<Enemy>();
            enemies = new List<Enemy>(FindObjectsOfType<Enemy>());
            player.gameObject.SetActive(false);
            player.Initialize();
        }

        public void DeadEnemy(Enemy enemy)
        {
            if (currentSpawningEnemies.ContainsKey(enemy)) return;

            int timer = Random.Range(MinDeathTime, MaxDeathTime);
            currentSpawningEnemies.Add(enemy, Time.time + timer);
        }

        public IEnumerable<Enemy> Enemy() => enemies;

        private void Update()
        {
            if (currentSpawningEnemies.Count == 0) return;

            foreach (var enemy in currentSpawningEnemies)
            {
                if(Time.time >= enemy.Value)
                    spawnedEnemy.Add(enemy.Key);
            }

            if (spawnedEnemy.Count != 0)
            {
                foreach (var enemy in spawnedEnemy)
                {
                    enemy.ResetEnemy();
                    currentSpawningEnemies.Remove(enemy);
                }

                spawnedEnemy.Clear();
            }
        }

        public void SpawnPlayer()
        {
            player.gameObject.SetActive(true);

            foreach (var enemy in enemies)
            {
                enemy.ResetEnemy();
            }
        }

        public void DespawnPlayer()
        {
            player.gameObject.SetActive(false);

            foreach (var enemy in enemies)
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }
}
