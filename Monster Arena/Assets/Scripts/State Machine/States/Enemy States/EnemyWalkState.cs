using UnityEngine;
using UnityEngine.UIElements;

public class EnemyWalkState : EnemyBaseState
{
    private float walkTime = 0f;
    public EnemyWalkState(Boss entity, EnemyStateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        walkTime = Random.Range(1, 3);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(walkTime <= 0)
        {
            entity.ChangeToRandomState();
        }
        else
        {
            walkTime -= Time.deltaTime;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}