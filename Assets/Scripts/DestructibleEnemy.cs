using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleEnemy : Enemy
{
    public int health;
    public Animator mAnimator;

    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }

    public void AnimationTrigger(string name)
    {
        mAnimator.SetTrigger(name);
    }

    public void AnimationBool(string name, bool value)
    {
        mAnimator.SetBool(name, value);
    }
}
