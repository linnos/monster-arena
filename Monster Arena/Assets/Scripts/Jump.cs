using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public float jumpSpeed;
    public bool isJumpPressed;
    
    float maxJumpTime = 0.5f;
    float maxJumpHeight = 1.0f;
    float initialJumpVelocity;

    private void Awake() {
        setupJumpVariables();
    }

    void setupJumpVariables(){
        float timeToApex = maxJumpTime / 2;
        // gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump_Event(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }
}
