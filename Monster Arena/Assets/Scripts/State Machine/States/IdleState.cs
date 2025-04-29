using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class IdleState : BaseState
{
    public IdleState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
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
        if (entity.movement.isMoving)
        {
            stateMachine.ChangeState(entity.walkState);
        }
        else if(entity.combat.attackingPressed){
            stateMachine.ChangeState(entity.attackState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}