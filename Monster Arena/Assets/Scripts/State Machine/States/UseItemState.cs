using UnityEngine;

public class UseItemState : BaseState
{
    private int animationCounter = 0;
    private bool itemUsed = false;
     public UseItemState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        animationCounter = 0;
        //Cancel out prior movement.
        entity.movement.zeroMovement();
    }

    public override void Exit()
    {
        itemUsed = false;
        base.Exit();
    }

    public override void Update()
    {
        if (entity.animationController.IsAnimationComplete())
        {
            animationCounter++;            
        }

        if(animationCounter == 1 && !itemUsed){
            entity.inventory.UseItem();
            entity.animationController.PlayAnimation("PowerUp");
            itemUsed = true;
        }
        else if(animationCounter == 2){
            stateMachine.ChangeState(entity.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
