
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public PlayerScriptableObject stats;
    public Transform camera;
    public Gravity gravity;
    public Vector3 direction = Vector3.zero;
    Vector2 input;
    protected float rotationFactor = 1.0f;
    public bool isMoving = false;
    public bool isRunning = false;

    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
        gravity = this.GetComponent<Gravity>();
    }
    private void Start()
    {
        input = Vector3.zero;
    }
    private void Update()
    {
        //TODO: Change this to work with new camera system.
        //Forward should move to where the camera is facing.
        HandleRotation();


        if (isMoving)
        {
            moveDirection();
        }


        if (isRunning)
        {
            characterController.Move(direction * stats.runSpeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(direction * Time.deltaTime);
        }

        gravity.HandleGravity(ref direction, characterController);
    }
    public void Move_Event(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isMoving = true;
        }
        else if (context.performed)
        {
            input = context.ReadValue<Vector2>();
            moveDirection();

            // direction.x = input.x * stats.movementSpeed;
            // direction.z = input.y * stats.movementSpeed;
        }
        else if (context.canceled)
        {
            direction.x = 0f;
            direction.z = 0f;
            isMoving = false;
        }

    }

    private void moveDirection()
    {
        Vector3 newDirection = camera.forward * input.y;
        newDirection = newDirection + camera.right * input.x;

        direction.x = newDirection.x * stats.movementSpeed;
        direction.z = newDirection.z * stats.movementSpeed;
    }

    public void Run_Event(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isRunning = true;

        }
        else if (context.performed)
        {

        }
        else if (context.canceled)
        {
            isRunning = false;
        }
    }

    void HandleRotation()
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

    public void Jump()
    {
        direction.y += stats.jumpSpeed;
    }
}
