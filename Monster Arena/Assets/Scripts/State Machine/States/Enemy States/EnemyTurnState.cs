using UnityEngine;
using UnityEngine.UIElements;

public class EnemyTurnState : EnemyBaseState
{
    public EnemyTurnState(Boss entity, EnemyStateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Vector3.Angle(entity.transform.forward, entity.playerTarget.transform.position - entity.transform.position) < entity.angle)
        {
            entity.ChangeToRandomAttackState();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}