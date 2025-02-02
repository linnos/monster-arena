using System;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public PlayerScriptableObject stats;
    public Vector3 direction = Vector3.zero;
    protected float rotationFactor = 1.0f;
    public bool isMoving = false;
    public bool isRunning = false;

    //Gravity variables
    public float groundedGravity = -0.05f;
    public float gravity = -9.8f;

    Vector2 input;

    private void Awake()
    {
        characterController = this.GetComponent<CharacterController>();
    }
    private void Start()
    {
        input = Vector3.zero;
    }
    private void Update()
    {
        HandleRotation();


        
        if(isRunning){
            characterController.Move(direction * stats.runSpeed * Time.deltaTime);
        }
        else{
            characterController.Move(direction * Time.deltaTime);
        }

        HandleGravity();
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

            direction.x = input.x * stats.movementSpeed;
            direction.z = input.y * stats.movementSpeed;
        }
        else if (context.canceled)
        {
            direction.x = 0f;
            direction.z = 0f;
            isMoving = false;
        }

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

    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            direction.y = groundedGravity;
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }
    }
}
