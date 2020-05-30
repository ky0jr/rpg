using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RPG.Menu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField]
        private Button startButton;

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
