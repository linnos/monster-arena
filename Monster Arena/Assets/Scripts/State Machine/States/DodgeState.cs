using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//TODO: disable hurt boxes for the player while dodging.
//Hurt box should turn off when dodging and turn back on when the dodge is close to being done.
//Should be able to dodge in any direction.
public class DodgeState : BaseState
{
    public DodgeState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        entity.animator.applyRootMotion = true;
        base.Enter();
    }

    public override void Exit()
    {
        entity.animator.applyRootMotion = false;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(entity.animationController.animationComplete){
            stateMachine.ChangeState(entity.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}