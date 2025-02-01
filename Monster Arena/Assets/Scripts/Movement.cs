using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public float movespeed = 0f;
    private Vector3 direction = Vector3.zero;
    private float rotationFactor = 1.0f;
    public bool isMoving = false;

    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
    }
    private void Start()
    {

    }
    private void Update()
    {
        handleRotation();
        characterController.Move(direction);

    }
    public void Move_Event(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isMoving = true;
        }
        else if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            direction.x = input.x * movespeed * Time.deltaTime;
            direction.z = input.y * movespeed * Time.deltaTime;


        }
        else if (context.canceled)
        {
            direction = Vector3.zero;
            isMoving = false;
        }

    }

    void handleRotation()
    {
        Vector3 positionToLookAt;
        //the change in position our character should point to
        positionToLookAt.x = direction.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = direction.z;

        // the current rotation of our character
        Quaternion currentRotation = transform.rotation;

        if (isMoving)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactor);
        }


    }
}
