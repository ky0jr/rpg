using RPG.Transition;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RPG.Game.Manager
{
    public class PauseManager : MonoBehaviour
    {
        public event System.Action<bool> OnPause;

        [SerializeField]
        private Button mainMenuButton;
        [SerializeField]
        private Canvas canvas;

        [SerializeField]
        private Crossfade crossfade;

        private bool isPause;

        private bool canPause;

        public void Initialize()
        {
            isPause = false;
            canvas.enabled = false;
            mainMenuButton.onClick.AddListener(MainMenu);
            canPause = true;
        }

        // Update is called once per frame
        void Update()
        {
            if(!canPause) return;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

        private void Pause()
        {
            isPause = !isPause;
            canvas.enabled = isPause;

            Cursor.visible = isPause;

            OnPause?.Invoke(isPause);

            if (isPause)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        private void MainMenu()
        {
            crossfade.Transition(() => { SceneManager.LoadScene("Main Menu"); });
        }

        public void EndGame()
        {
            canPause = false;
            Pause();
        }
    }
}
