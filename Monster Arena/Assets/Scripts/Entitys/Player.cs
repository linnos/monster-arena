using UnityEngine;

public class Player : Entity
{
    public Animator animator;
    public CharacterController characterController;
    public Movement movement;
    public ScriptableObject player;

    //State machine and states

    public StateMachineManager stateMachine { get; set; }

    public IdleState idleState { get; set; }
    public WalkState walkState { get; set; }
    public RunState runState { get; set; }
    public JumpState jumpState {get; set; }

    private void Awake()
    {
        stateMachine = new StateMachineManager();
        
        idleState = new IdleState(this, stateMachine);
        walkState = new WalkState(this, stateMachine);
        runState = new RunState(this, stateMachine);
        jumpState = new JumpState(this, stateMachine);
    }
    private void Start()
    {
        animator = this.GetComponent<Animator>();
        characterController = this.GetComponent<CharacterController>();
        movement = this.GetComponent<Movement>();

        stateMachine.Initialize(idleState);
    }

    private void Update() {
        stateMachine.currentState.Update();
    }

    private void FixedUpdate() {
        stateMachine.currentState.PhysicsUpdate();
    }
}