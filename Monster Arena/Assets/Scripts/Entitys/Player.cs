using UnityEngine;

public class Player : Entity
{
    public Animator animator;

    public StateMachineManager stateMachine { get; set; }

    public IdleState idleState { get; set; }
    public RunState runState { get; set; }

    private void Awake()
    {
        stateMachine = new StateMachineManager();

        idleState = new IdleState(this, stateMachine);
        runState = new RunState(this, stateMachine);
    }
    private void Start()
    {
        animator = this.GetComponent<Animator>();

        stateMachine.Initialize(idleState);
    }

    private void Update() {
        stateMachine.currentState.Update();
    }

    private void FixedUpdate() {
        stateMachine.currentState.PhysicsUpdate();
    }
}