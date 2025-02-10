using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public string currAnim;
    public bool animationComplete = false;
    public bool canTransition = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        animationComplete = IsAnimationComplete();

    }
    private void Start()
    {

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
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0);
    }
}
