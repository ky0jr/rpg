using TMPro;
using UnityEngine;

namespace RPG.Menu
{
    public class HighScore : MonoBehaviour
    {
        private const string SaveKey = "HighScore";
        
        [SerializeField]
        private TMP_Text text;
        
        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.HasKey(SaveKey))
            {
                int score = PlayerPrefs.GetInt(SaveKey);
                text.text = $"High Score \n {score}";
            }
        }
    }
}
