using Unity.VisualScripting;

public class IdleState : BaseState
{
    public IdleState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
        
    }

    public override void Enter()
    {        
        entity.animator.Play("Idle");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(entity.movement.isMoving){
            stateMachine.ChangeState(entity.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}