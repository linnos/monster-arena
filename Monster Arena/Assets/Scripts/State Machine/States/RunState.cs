public class RunState : BaseState
{
    public RunState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        entity.animator.Play("Run");
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
        if(!entity.movement.isRunning){
            stateMachine.ChangeState(entity.walkState);
        }
        if(!entity.characterController.isGrounded){
            stateMachine.ChangeState(entity.jumpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}