using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ActivateGrowUpAnimation()
    {

        animator.SetTrigger("GrowUp");
    }

    public void ActivateDownAnimation()
    {

        animator.SetTrigger("Down");
    }

    public void ActivateStarAnimation()
    {

        animator.SetTrigger("Star");
    }
}

