using UnityEngine;

public class StartAnimationTrigger : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation()
    {
        animator.SetTrigger("StartAnimation");
    }
}
