using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity
{
    #region components
    public Animator animator;
    public AnimationController animationController;
    public BossScriptableObject boss;
    public Player playerTarget;
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
    //Todo: Remove this later. This is just for testing purposes.
    public List<EnemyBaseState> states { get; set; } = new List<EnemyBaseState>();
    public List<EnemyBaseState> attackStates { get; set; } = new List<EnemyBaseState>();
    public AudioSource audioSource;
    public AudioClip victoryAudioSource;
    #endregion
    //TODO: Remove this later. This is just for testing purposes.
    [SerializeField]
    [Range(0, 100)]
    public float attackRange = 1.5f;
    [SerializeField]
    [Range(0, 100)]
    public float runAttackRange = 2.5f;
    //Angle to check if the player is in front of the enemy.
    [SerializeField]
    [Range(0, 180)]
    public float angle = 2.5f;

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

        states.Add(idleState);
        states.Add(walkState);
        states.Add(runState);
        states.Add(attackState);

        attackStates.Add(attackState);
        attackStates.Add(runState);

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
        if (Random.Range(0, 100) < 30)
        {
            stateMachine.ChangeState(knockedState);
        }
    }

    public void ChangeToRandomState()
    {
        EnemyBaseState newState = null;
        Debug.Log("Angle: " +Vector3.Angle(transform.forward, playerTarget.transform.position - transform.position) );
        if (Vector3.Angle(transform.forward, playerTarget.transform.position - transform.position) > angle)
        {
            // Get a random state from the list of states
            stateMachine.ChangeState(turnState);
            return;
        }
        else{
            List<EnemyBaseState> allStates = states;
            allStates.Add(attackState);
            allStates.Add(runState);

            newState = allStates[Random.Range(0, states.Count)];
        }
        // Change to the new state
        stateMachine.ChangeState(newState);
    }

    public void ChangeToRandomAttackState()
    {
        EnemyBaseState newState = newState = states[Random.Range(0, states.Count)];
        // Change to the new state
        stateMachine.ChangeState(newState);
    }    
}
