using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RPG.Menu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField]
        private Button startButton;
        
        [SerializeField]
        private List<GameObject> dontDestroyOnLoad;

        private void Awake()
        {
            foreach (GameObject gameObject in dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        private void Start()
        {
            startButton.onClick.AddListener(LoadGame);
        }

        private void LoadGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
