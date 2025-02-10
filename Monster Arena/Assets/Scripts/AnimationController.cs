using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public string currAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake() {
        animator = this.GetComponent<Animator>();
    }

    private void Start() {
    }

    public void PlayAnimation(string animName){
        if(currAnim != animName){
            Debug.Log(animName);
            currAnim = animName;
            animator.CrossFade(animName, 0.05f);
        }
    }
}
