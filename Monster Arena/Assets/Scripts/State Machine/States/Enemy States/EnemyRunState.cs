using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRunState : EnemyBaseState
{
    private float runTime = 0;
    public EnemyRunState(Boss entity, EnemyStateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        runTime = Random.Range(3, 8);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(runTime <= 0)
        {
            entity.ChangeToRandomState();
        }
        else
        {
            runTime -= Time.deltaTime;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}