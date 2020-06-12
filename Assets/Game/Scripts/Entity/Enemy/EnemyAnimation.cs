using UnityEngine;
using Random = UnityEngine.Random;

namespace RPG.Game.Entity
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimation : MonoBehaviour
    {
        private const float MinAnimationTime = 2f;

        private const float MaxAnimationTime = 5f;
        enum EnemyLook
        {
            Front = 1,
            Left,
            Right,
            Back
        }

        private static readonly int Death = Animator.StringToHash("death");

        private Animator animator;

        private float updateTime = 0f;

        [SerializeField]
        private EnemyLook lastLook;

        private bool isUpdating;

        private bool isInitialized = false;

        // Start is called before the first frame update
        private void Initialize()
        {
            animator = GetComponent<Animator>();
            GetComponent<IDeath>().OnDeathEvent += () =>
            {
                animator.SetTrigger(Death);
                isUpdating = false;
            };
        }

        public void ResetAnimation()
        {
            if(!isInitialized)
                Initialize();

            lastLook = EnemyLook.Front;
            UpdateAnimation();
            isUpdating = true;
        }

        private void Update()
        {
            if(!isUpdating)
                return;

            if (Time.time >= updateTime)
            {
                UpdateAnimation();
            }
        }

        private void UpdateAnimation()
        {
            var look = lastLook;

            while (look == lastLook)
            {
                look = (EnemyLook)Random.Range(0, 4) + 1;
            }

            lastLook = look;

            animator.SetTrigger(look.ToString().ToLower());

            updateTime = Time.time + Random.Range(MinAnimationTime, MaxAnimationTime);
        }
    }
}
