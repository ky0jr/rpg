using UnityEngine;

namespace RPG.Game.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        private const string SaveKey = "HighScore";

        private int highScore;

        [SerializeField]
        private Score scoreCanvas;

        public event System.Action<int> OnScoreChanged;
        public int Score { get; private set; }

        public void AddScore(int value)
        {
            Score += value;

            if (Score > highScore)
            {
                PlayerPrefs.SetInt(SaveKey, Score);
            }

            OnScoreChanged?.Invoke(Score);
        }

        public void Initialize()
        {
            scoreCanvas.Initialized();

            Score = 0;

            if (PlayerPrefs.HasKey(SaveKey))
            {
                highScore = PlayerPrefs.GetInt(SaveKey);
            }
            else
            {
                highScore = 0;
            }

            OnScoreChanged?.Invoke(Score);
        }
    }
}
