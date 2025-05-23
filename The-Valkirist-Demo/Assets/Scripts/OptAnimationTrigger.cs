using UnityEngine;

public class OptAnimationTrigger : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation()
    {
        animator.SetTrigger("OptStart");
    }
}
