using System;
using System.Collections;
using UnityEngine;

namespace RPG.Transition
{
    public class Crossfade : MonoBehaviour
    {
        private Animator animator;
        private Canvas canvas;
        private static readonly int Start = Animator.StringToHash("Start");

        private bool isRunning;

        void Awake()
        {
            animator = GetComponent<Animator>();
            canvas = GetComponent<Canvas>();
            isRunning = false;
            canvas.enabled = true;
        }

        public void Transition(Action playEvent)
        {
            if (isRunning)
                return;

            StopCoroutine(PlayTransition(playEvent));
            StartCoroutine(PlayTransition(playEvent));
        }

        private IEnumerator PlayTransition(Action playEvent)
        {
            Time.timeScale = 1;
            animator.SetTrigger(Start);
            isRunning = true;

            yield return new WaitForSeconds(0.5f);

            playEvent?.Invoke();
            isRunning = false;
        }
    }
}
