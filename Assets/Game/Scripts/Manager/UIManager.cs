using UnityEngine;
namespace RPG.Game.Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Score score;

        public void Initialized()
        {
            score.Initialized();
        }
    }
}