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
        [SerializeField] private UIManager uiManager;
        [SerializeField] private DropManager dropManager;

        public ScoreManager ScoreManager => scoreManager;

        private void Start()
        {
            uiManager.Initialized();
            scoreManager.Reset();
            dropManager.Initialize();
        }    
    }
}