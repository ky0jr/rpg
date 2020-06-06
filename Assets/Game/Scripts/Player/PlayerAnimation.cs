using RPG.Game.Entity;
using RPG.Game.Player;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private static readonly int Vertical = Animator.StringToHash("vertical");
    private static readonly int Horizontal = Animator.StringToHash("horizontal");
    private static readonly int Facing = Animator.StringToHash("facing");
    private static readonly int Attack = Animator.StringToHash("attack");

    public event System.Action<int> OnFacingChange;
    
    private Animator animator;
    private PlayerInput input;
    private int facing = 1;

    private bool attack = false;
    
    // Start is called before the first frame update
    public void Initialize()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        GetComponent<IAttack>().OnAttackEvent += () => SetAttack(false);
        input.OnFire += () => SetAttack(true);
    }

    private void Update()
    {
        if (attack)
        {
            animator.SetFloat(Vertical, 0f);
            animator.SetFloat(Horizontal, 0f);
            return;
        }
        
        if (Mathf.Abs(input.Vertical) > 0)
        {
            animator.SetFloat(Vertical, input.Vertical);
            animator.SetFloat(Horizontal, 0f);
            facing = input.Vertical < 0 ? 1 : 2;
            OnFacingChange?.Invoke(facing);
        }
        else if (Mathf.Abs(input.Horizontal) > 0)
        {
            animator.SetFloat(Horizontal, input.Horizontal);
            animator.SetFloat(Vertical, 0f);
            facing = input.Horizontal < 0 ? 3 : 4;
            OnFacingChange?.Invoke(facing);
        }
        else
        {
            animator.SetFloat(Vertical, 0f);
            animator.SetFloat(Horizontal, 0f);
        }

        animator.SetInteger(Facing, facing);
    }

    private void SetAttack(bool val)
    {
        attack = val;
        animator.SetBool(Attack, attack);
    }
}
