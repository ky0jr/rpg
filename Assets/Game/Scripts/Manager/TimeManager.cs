using System;
using TMPro;
using UnityEngine;

namespace RPG.Game.Manager
{
    public class TimeManager : MonoBehaviour
    {
        public event Action OnGameStart;

        public event Action OnGameEnd;
        
        private const float GameDuration = 100;

        private float timeEnd = 0f;

        private float countDown = 0f;
        
        [SerializeField]
        private Canvas countDownCanvas;

        [SerializeField]
        private TMP_Text countDownText;

        [SerializeField] 
        private Canvas timerCanvas;
        
        [SerializeField] 
        private TMP_Text timerText;

        private bool gameStart;
        private bool gameEnd;

        public void Initialize()
        {
            countDown = 3.5f;
            gameStart = false;
            gameEnd = false;
            countDownCanvas.enabled = true;
            Time.timeScale = 1;
        }

        private void Update()
        {
            CountDown();
            Timer();
        }

        private void CountDown()
        {
            if (gameStart || gameEnd)
            {
                return;
            }
            
            countDown -= Time.deltaTime;
            countDownText.text = ((int) countDown).ToString();

            if (countDown <= 0f)
            {
                countDownCanvas.enabled = false;
                OnGameStart?.Invoke();
                gameStart = true;
            }
        }

        private void Timer()
        {
            if(!gameStart || gameEnd) return;

            if (timeEnd <= 0)
            {
                timeEnd = Time.time + GameDuration;
                timerCanvas.enabled = true;
            }

            int time = (int)(timeEnd - Time.time);

            timerText.text = time.ToString();
            
            if (Time.time >= timeEnd)
            {
                OnGameEnd?.Invoke();
                gameEnd = true;
            }
        }
    }
}
