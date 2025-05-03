
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.VisualScripting;
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
    public bool canMove { get; set; } = true;
    public bool lockMoveDirection { get; set; } = false;

    //Trying out this playing information class as a way to get information about the player without having to pass it around everywhere.
    public PlayerInformation playerInformation;

    //States that you are not able to move in. Similar to combat scripts dodgeable states
    public List<string> nonMoveableStates;

    private void Awake()
    {
        if(!playerInformation){
            throw new System.Exception("PlayerInformation is not set in the inspector. Please set it to the player object.");
        }
        
        characterController = this.GetComponent<CharacterController>();
        gravity = this.GetComponent<Gravity>();
    }
    private void Start()
    {
        input = Vector3.zero;
    }

    //TODO: Need to be able to dodge and jump while keeping momentum, but not movement.
    private void Update()
    {

        HandleRotation();


        if (isMoving)
        {
            moveDirection();
        }


        if (isRunning && playerInformation.isPlayerInState("RunState"))
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
        if(lockMoveDirection){
            return;
        }

        if (context.started)
        {
            isMoving = true;
        }
        else if (context.performed)
        {
            input = context.ReadValue<Vector2>();
            moveDirection();
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
        
        if(lockMoveDirection || !canMove){
            return;
        }
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
        if(lockMoveDirection || !canMove){
            return;
        }

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
        lockMoveDirection = true;
        direction.y += stats.jumpSpeed;
    }

    //Checks the string for states that are not able to move in. Also checks for "true" so that it can be set in the animation event.
    public void CanMove(string state)
    {
        if(state.ToLower() == "true"){
            canMove = true;
            return;
        }
        canMove = !nonMoveableStates.Contains(Regex.Replace(state,"[0-9]", ""));
        // Debug.Log($"Can move : {canMove} in animation state: {state.ToLower()}");
        if(canMove){
            lockMoveDirection = false;
        }
    }

    public void Dodge(){
        lockMoveDirection = true;
    }
}
