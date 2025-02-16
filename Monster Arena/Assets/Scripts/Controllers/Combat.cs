using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Combat : MonoBehaviour
{

    //Keep track of buttons that are pressed
    public bool attackingPressed = false;
    public bool attackingReleased = true;
    public bool dodgePressed = false;

    //Can the character dodge right now?
    public bool canDodge { get; set; }

    //List of states that you are allowed to dodge in.
    public List<string> dodgeableStates;

    public Action OnDodge;

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
            dodgePressed = true;
            if (canDodge)
            {
                OnDodge?.Invoke();
            }
        }
        else if (context.performed)
        {
            
        }
        else if (context.canceled)
        {
            dodgePressed = false;
        }
    }

    //Checks the string for states that are able to dodge. Also checks for "true" so that it can be set in the animation event.
    //Can also be set in an animation event such as for attacks. Just set to true.
    public void CanDodge(string state)
    {
        if(state.ToLower() == "true"){
            canDodge = true;
            return;
        }
        canDodge = dodgeableStates.Contains(state);
    }
}
