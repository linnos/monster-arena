using System;
using NUnit.Framework;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{
    //TODO: Need to find a way to decouple this from the AttackState.
    
    //Keep track of buttons that are pressed
    public bool attackingPressed = false;
    public bool attackingReleased = true;
    public bool dodgePressed = false;

    //Can the character dodge right now?
    public bool canDodge { get; set; }
    
    private void Awake()
    {
    }
    private void Start()
    {
    }
    private void Update()
    {
    }
    public void Attack_Event(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            
        }
        else if (context.performed)
        {
            attackingPressed = true;
             
        }
        else if (context.canceled)
        {
            attackingPressed = false;
        }
    }

    public void Dodge_Event(InputAction.CallbackContext context)
    {
        if (context.started)
        {
        }
        else if (context.performed)
        {
            dodgePressed = true;
        }
        else if (context.canceled)
        {
            dodgePressed = false;
        }
    }

    public void CanDodoge(){
        canDodge = true;
    }
    public void CantDodoge(){
        canDodge = false;
    }
}
