using System.Collections.Generic;
using RPG.Transition;
using TMPro;
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
        private Button exitButton;

        [SerializeField]
        private Crossfade crossfade;

        [SerializeField]
        private TMP_Text versionText;

        [SerializeField]
        private List<GameObject> dontDestroyOnLoad;

        private void Awake()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            foreach (GameObject gameObject in dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }

            versionText.text = $"Version: \n {Application.version}";
        }

        private void Start()
        {
            startButton.onClick.AddListener(LoadGame);
            exitButton.onClick.AddListener(Application.Quit);
        }

        private void LoadGame()
        {
            crossfade.Transition(() => { SceneManager.LoadScene("Game"); });
        }
    }
}
