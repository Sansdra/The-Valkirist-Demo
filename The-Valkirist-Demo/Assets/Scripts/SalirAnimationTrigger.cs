using UnityEngine;

public class SalirAnimationTrigger : MonoBehaviour
{
    public Animator animator;

    public void PlayAnimation()
    {
        animator.SetTrigger("StartAnimation");
    }
}
