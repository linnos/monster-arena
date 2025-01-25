using UnityEngine;

public class StateMachineManager
{
    public BaseState currentState { get; set; }

    public void Initialize(BaseState startingState){
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
        currentState.Enter();
    }
}
