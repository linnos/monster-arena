public class WalkState : BaseState
{
    public WalkState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        entity.animator.Play("Walk");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(!entity.movement.isMoving){
            stateMachine.ChangeState(entity.idleState);
        }
        if(entity.movement.isRunning){
            stateMachine.ChangeState(entity.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}