using RPG.Game.Player;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private static readonly int Vertical = Animator.StringToHash("vertical");
    private static readonly int Horizontal = Animator.StringToHash("horizontal");
    private static readonly int Facing = Animator.StringToHash("facing");
    private Animator animator;
    private PlayerInput input;
    private int facing = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (Mathf.Abs(input.Vertical) > 0)
        {
            animator.SetInteger(Vertical, (int)input.Vertical);
            animator.SetInteger(Horizontal, 0);
            facing = input.Vertical < 0 ? 1 : 2;
        }
        else if (Mathf.Abs(input.Horizontal) > 0)
        {
            animator.SetInteger(Horizontal, (int)input.Horizontal);
            animator.SetInteger(Vertical, 0);
            facing = input.Horizontal < 0 ? 3 : 4;
        }
        else
        {
            animator.SetInteger(Vertical, 0);
            animator.SetInteger(Horizontal, 0);
        }

        animator.SetInteger(Facing, facing);
    }
}
