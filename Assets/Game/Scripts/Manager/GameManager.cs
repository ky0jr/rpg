using RPG.Game.Entity;
using RPG.Game.Manager;
using UnityEngine;

namespace RPG.Game
{
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        public static GameManager Current => current;

        private static GameManager current;

        private void Awake()
        {
            if (current == null)
            {
                current = this;
            }
            else
            {
                Debug.LogError("There is 2 GameManager");
                Destroy(this);
            }

        }

        #endregion

        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private DropManager dropManager;
        [SerializeField] private SpawnManager spawnManager;
        [SerializeField] private TimeManager timeManager;
        [SerializeField] private PauseManager pauseManager;

        public ScoreManager ScoreManager => scoreManager;

        private void Start()
        {
            timeManager.OnGameStart += spawnManager.SpawnPlayer;
            timeManager.OnGameStart += scoreManager.Initialize;
            timeManager.OnGameEnd += spawnManager.DespawnPlayer;
            timeManager.OnGameEnd += pauseManager.EndGame;
            pauseManager.Initialize();
            spawnManager.Initialize();
            dropManager.Initialize(spawnManager.Enemy());
            timeManager.Initialize();
            Cursor.visible = false;
        }

        public void Death(Enemy enemy)
        {
            spawnManager.DeadEnemy(enemy);
        }
    }
}
