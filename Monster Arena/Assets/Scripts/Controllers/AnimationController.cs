using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public string currAnim;
    public bool animationComplete = false;
    public bool canTransition = false;


    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        animationComplete = IsAnimationComplete();
    }

    public void PlayAnimation(string animName)
    {
        if (currAnim != animName)
        {
            currAnim = animName;
            animator.CrossFade(animName, 0.05f);
        }
    }

    public void AnimationComplete()
    {
        animationComplete = true;
    }
    
    public bool IsAnimationComplete(){
        if(animator.IsInTransition(0)){
            return false;
        }
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1);
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.GetCurrentAnimatorStateInfo(0).loop;
    }
}
