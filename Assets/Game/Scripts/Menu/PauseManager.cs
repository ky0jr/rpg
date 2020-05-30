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
        
        private bool isPause;
        
        private void Awake()
        {
            isPause = false;
            canvas.enabled = false;
            mainMenuButton.onClick.AddListener(MainMenu);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
        }

        private void Pause()
        {
            isPause = !isPause;
            canvas.enabled = isPause;
            
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
            SceneManager.LoadScene("Main Menu");
        }
    }
}
