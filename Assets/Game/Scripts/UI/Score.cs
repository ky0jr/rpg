using RPG.Game;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    public void Initialized()
    {
        GameManager.Current.ScoreManager.OnScoreChanged += ScoreChange;
    }

    private void ScoreChange(int value)
    {
        scoreText.text = $"Score: {value}";
    }
}
