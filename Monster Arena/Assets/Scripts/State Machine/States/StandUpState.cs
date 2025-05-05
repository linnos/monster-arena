public class StandUpState : BaseState
{
    //TODO: Disable hurt boxes for the player getting up.
    public StandUpState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
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
        if (entity.animationController.IsAnimationComplete())
        {
            stateMachine.ChangeState(entity.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}