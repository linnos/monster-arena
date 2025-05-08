using UnityEngine;

public class Boss : Entity
{
    #region components
    public Animator animator;
    public AnimationController animationController;
    public BossScriptableObject boss;
    #endregion

    #region colliders
    public TriggerDamage swordTriggerDamage;
    public Collider swordCollider;
    public TriggerDamage kickDamage;
    public Collider kickCollider;
    #endregion



    //State machine and states
    #region stateMachine and states
    public EnemyStateMachineManager stateMachine { get; set; }

    public EnemyIdleState idleState { get; set; }
    public EnemyWalkState walkState { get; set; }
    public EnemyRunState runState { get; set; }
    public EnemyTurnState turnState { get; set; }
    public EnemyKnockedState knockedState { get; set; }
    public EnemyDeathState deathState { get; set; }
    public EnemyAttack1State attackState { get; set; }
    #endregion

    private void Awake()
    {

        stateMachine = new EnemyStateMachineManager();

        idleState = new EnemyIdleState(this, stateMachine);
        walkState = new EnemyWalkState(this, stateMachine);
        runState = new EnemyRunState(this, stateMachine);
        attackState = new EnemyAttack1State(this, stateMachine);
        deathState = new EnemyDeathState(this, stateMachine);
        knockedState = new EnemyKnockedState(this, stateMachine);
        turnState = new EnemyTurnState(this, stateMachine);

        this.maxHealth = boss.health;
    }
    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator>();
        animationController = this.GetComponent<AnimationController>();

        stateMachine.OnStateChange += animationController.PlayAnimation;
        this.OnDeath += TriggerDeath;
        this.OnDamageTaken += TriggerDamage;
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
