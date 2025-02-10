using UnityEngine.Events;
using UnityEngine.InputSystem;

public class DodgeState : BaseState
{
    public DodgeState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
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
        if( entity.animationController.animationComplete){
            stateMachine.ChangeState(entity.idleState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}