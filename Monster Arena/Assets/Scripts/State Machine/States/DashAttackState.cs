public class DashAttackState : BaseState
{
    public DashAttackState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        entity.kickCollider.enabled = true;
        entity.kickDamage.enabled = true;
        base.Enter();
    }

    public override void Exit()
    {
        entity.kickCollider.enabled = false;
        entity.kickDamage.enabled = false;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        if ( entity.animationController.animationComplete)
        {
            stateMachine.ChangeState(entity.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}