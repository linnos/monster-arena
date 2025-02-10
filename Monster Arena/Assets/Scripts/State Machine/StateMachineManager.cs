using System;
using UnityEngine;

public class StateMachineManager
{
    public BaseState currentState { get; set; }
    public Action<string> OnStateChange;

    //
    private string stateName;

    public void Initialize(BaseState startingState)
    {
        ChangeStateEvent(startingState);

        currentState = startingState;
        currentState.Enter();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    public void ChangeState(BaseState newState){
        currentState.Exit();
        currentState = newState;
        ChangeStateEvent(currentState);
        currentState.Enter();
    }

    //A helper method to send out an event when the state is changed.
    //Sends out a string of state name without the "State" portion
    private void ChangeStateEvent(BaseState state)
    {
        stateName = state.GetType().FullName;

        OnStateChange?.Invoke(stateName.Remove(stateName.Length - "State".Length));
    }

    //an override to the ChangeStateEvent. This is useful for tricky states such as
    //the attack state which can create combos, but is still in the same attacking state.
    //**MAY NEED TO CHANGE THIS
    public void ChangeStateEventString(string input)
    {
        //MAKE SURE THIS ANIMATION NAME EXISTS IN ANIMATOR
        OnStateChange?.Invoke(input);
    }
}
