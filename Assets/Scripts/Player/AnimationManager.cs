using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetDirection(Vector2 direction)
    {
        animator.SetFloat("DirX", direction.x);
        animator.SetFloat("DirY", direction.y);
    }

    public void SetSpeed(float speed)
    {
        animator.SetFloat("Speed", speed);
    }

    public void SetRunning(bool running)
    {
        animator.SetBool("Running", running);
    }
}
