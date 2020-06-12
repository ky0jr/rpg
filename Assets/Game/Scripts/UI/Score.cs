using RPG.Game;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private Canvas canvas;
    public void Initialized()
    {
        GameManager.Current.ScoreManager.OnScoreChanged += ScoreChange;
        canvas.enabled = true;
    }

    private void ScoreChange(int value)
    {
        scoreText.text = $"Score: {value}";
    }
}
