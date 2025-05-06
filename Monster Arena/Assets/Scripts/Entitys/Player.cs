using System;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    #region components
    public Animator animator;
    public AnimationController animationController;
    public CharacterController characterController;
    public Movement movement;
    public Combat combat;
    public PlayerScriptableObject player;
    public StaminaManager staminaManager;
    public Inventory inventory;
    #endregion

    #region colliders
    public TriggerDamage swordTriggerDamage;
    public Collider swordCollider;
    public TriggerDamage kickDamage;
    public Collider kickCollider;
    #endregion



    //State machine and states
    #region stateMachine and states
    public StateMachineManager stateMachine { get; set; }

    public IdleState idleState { get; set; }
    public WalkState walkState { get; set; }
    public RunState runState { get; set; }
    public JumpState jumpState { get; set; }
    public Attack1State attackState { get; set; }
    public DodgeState dodgeState { get; set; }
    public DashAttackState dashAttackState { get; set; }
    public DeathState deathState { get; set; }
    public KnockedState knockedState { get; set; }
    public StandUpState standUpState { get; set; }
    public UseItemState useItemState { get; set; }
    #endregion

    private void Awake()
    {

        stateMachine = new StateMachineManager();

        idleState = new IdleState(this, stateMachine);
        walkState = new WalkState(this, stateMachine);
        runState = new RunState(this, stateMachine);
        jumpState = new JumpState(this, stateMachine);
        attackState = new Attack1State(this, stateMachine);
        dodgeState = new DodgeState(this, stateMachine);
        dashAttackState = new DashAttackState(this, stateMachine);
        deathState = new DeathState(this, stateMachine);
        knockedState = new KnockedState(this, stateMachine);
        standUpState = new StandUpState(this, stateMachine);
        useItemState = new UseItemState(this, stateMachine);

        this.maxHealth = player.health;
        this.staminaManager.maxStamina = player.stamina;
    }
    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        animationController = this.GetComponent<AnimationController>();
        characterController = this.GetComponent<CharacterController>();
        movement = this.GetComponent<Movement>();
        combat = this.GetComponent<Combat>();

        stateMachine.OnStateChange += animationController.PlayAnimation;
        stateMachine.OnStateChange += combat.CanDodge;
        stateMachine.OnStateChange += movement.CanMove;
        combat.OnDodge += Dodge;
        this.OnDeath += TriggerDeath;
        this.OnDamageTaken += TriggerDamage;
        inventory.OnItemUsed += this.HealDamage; 
        stateMachine.Initialize(idleState);

    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public void Dodge()
    {
        if (!combat.canDodge)
        {
            return;
        }
        if (!combat.dodgePressed)
        {
            return;
        }

        if (staminaManager.UseStamina(player.dodgeStaminaCost))
        {
            stateMachine.ChangeState(dodgeState);
        }
    }

    public void TriggerDeath()
    {
        stateMachine.ChangeState(deathState);
    }

    public void TriggerDamage(int damage)
    {
        if (damage > 10)
        {
            stateMachine.ChangeState(knockedState);
        }
    }
}