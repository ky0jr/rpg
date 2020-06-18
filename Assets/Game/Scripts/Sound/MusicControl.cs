using UnityEngine;

namespace RPG.Game.Sound
{
    public class MusicControl : MonoBehaviour
    {
        private AudioSource audioSource;

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                audioSource.mute = !audioSource.mute;
            }

            if (Input.GetKey(KeyCode.LeftBracket))
            {
                audioSource.volume -= 0.002f;
            }
            else if (Input.GetKey(KeyCode.RightBracket))
            {
                audioSource.volume += 0.002f;
            }
        }
    }
}
