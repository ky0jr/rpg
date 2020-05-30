using UnityEngine;

namespace RPG.Game.Manager
{
    public class ScoreManager : MonoBehaviour
    {
        private const string SaveKey = "HighScore";
        
        public event System.Action<int> OnScoreChanged; 
        public int Score { get; private set; }
        
        public void AddScore(int value)
        {
            Score += value;
            PlayerPrefs.SetInt(SaveKey, Score);
            OnScoreChanged?.Invoke(Score);
        }

        public void Reset()
        {
            Score = 0;
            OnScoreChanged?.Invoke(Score);
        }
    }
}