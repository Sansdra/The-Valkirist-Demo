using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation()
    {
        animator.SetTrigger("StartAnimation");
    }
}
