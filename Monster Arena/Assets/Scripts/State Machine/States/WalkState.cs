public class WalkState : BaseState
{
    public WalkState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
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
        if(!entity.movement.isMoving){
            stateMachine.ChangeState(entity.idleState);
        }
        else if(entity.movement.isRunning && entity.staminaManager.UseStamina(entity.player.runStaminaCost)){
            stateMachine.ChangeState(entity.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}