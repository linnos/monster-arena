using UnityEngine;

public class Gravity : MonoBehaviour
{
    //Gravity variables
    public float groundedGravity = -0.05f;
    public float gravity = -9.8f;
    private float originalGravity;
    public float maxGravity = -50f;

    //How fast gravity increases while not on the ground
    public float accelerationFactor = -1f;

    private void Awake() {
        originalGravity = gravity;
    }
    
    //Pass in a direction vector and a character controller to add some gravity.
    //**Make sure to add gravity component to object.
    public void HandleGravity(ref Vector3 direction, CharacterController characterController)
    {
        if (characterController.isGrounded)
        {
            direction.y = groundedGravity;
            gravity = originalGravity;
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
            gravity = Mathf.Clamp(gravity + accelerationFactor, originalGravity, maxGravity);
        }
    }
}
