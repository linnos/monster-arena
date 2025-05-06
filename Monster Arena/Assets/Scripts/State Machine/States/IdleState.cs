using UnityEngine;
using UnityEngine.UIElements;

public class IdleState : BaseState
{
    public IdleState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        entity.movement.zeroMovement();
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
        //TODO: Need to figure out a way to make it so this will not happen if the player
        //has full health.
        else if(entity.combat.useItemPressed && entity.inventory.PrepareItem()){
            stateMachine.ChangeState(entity.useItemState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}