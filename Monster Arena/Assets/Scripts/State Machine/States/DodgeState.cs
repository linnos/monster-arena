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
        entity.combat.canDodge = false;
    }

    public override void Exit()
    {
        base.Exit();
        entity.animationComplete = false;
    }

    public override void Update()
    {
        base.Update();
        if(entity.animationComplete){
            stateMachine.ChangeState(entity.idleState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}