using System;
using TMPro;
using UnityEngine;

namespace RPG.Game.Manager
{
    public class TimeManager : MonoBehaviour
    {
        public event Action OnGameStart;

        private const float GameDuration = 120;

        private float timeEnd = 0f;

        private float countDown = 0f;

        [SerializeField]
        private Canvas countDownCanvas;

        [SerializeField]
        private TMP_Text countDownText;

        [SerializeField] private TMP_Text timerText;

        private bool gameStart;

        public void Initialize()
        {
            countDown = 3.5f;
            gameStart = false;
        }

        private void Update()
        {
            if (!gameStart)
            {
                countDown -= Time.deltaTime;
                countDownText.text = ((int) countDown).ToString();

                if (countDown <= 0f)
                {
                    countDownCanvas.enabled = false;
                    OnGameStart?.Invoke();
                    gameStart = true;
                }
            }
        }
    }
}
