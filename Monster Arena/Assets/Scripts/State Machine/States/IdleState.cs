public class IdleState : BaseState
{
    public IdleState(Entity entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        //Just testing this out. It works, but there might be a problem with it later on.
        Player player  = entity as Player;
        player.animator.Play("Idle");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}