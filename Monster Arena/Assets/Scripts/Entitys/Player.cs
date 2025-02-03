using System;
using UnityEngine;

public class Player : Entity
{
    public Animator animator;
    public CharacterController characterController;
    public Movement movement;
    public Combat combat;
    public ScriptableObject player;
    public bool animationComplete = false;

    //State machine and states

    public StateMachineManager stateMachine { get; set; }

    public IdleState idleState { get; set; }
    public WalkState walkState { get; set; }
    public RunState runState { get; set; }
    public JumpState jumpState {get; set; }
    public AttackState attackState { get; set; }
    public DodgeState dodgeState { get; set; }

    private void Awake()
    {
        stateMachine = new StateMachineManager();
        
        idleState = new IdleState(this, stateMachine);
        walkState = new WalkState(this, stateMachine);
        runState = new RunState(this, stateMachine);
        jumpState = new JumpState(this, stateMachine);
        attackState = new AttackState(this, stateMachine);
        dodgeState = new DodgeState(this, stateMachine);
    }
    private void Start()
    {
        animator = this.GetComponent<Animator>();
        characterController = this.GetComponent<CharacterController>();
        movement = this.GetComponent<Movement>();
        combat = this.GetComponent<Combat>();

        stateMachine.Initialize(idleState);
    }

    private void Update() {
        dodge();
        stateMachine.currentState.Update();
    }

    private void FixedUpdate() {
        stateMachine.currentState.PhysicsUpdate();
    }

    public void AnimationComplete() {
        animationComplete = true;
    }

    public void dodge(){
        if(combat.canDodge && combat.dodgePressed){
            stateMachine.ChangeState(dodgeState);
        }
    }
}
