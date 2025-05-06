using UnityEngine;
using UnityEngine.UIElements;

public class KnockedState : BaseState
{
    //TODO: Disable hurt boxes for the player while knocked.
    public KnockedState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        entity.animator.applyRootMotion = true;

        //Cancel out prior movement. This is important because the player can be knocked while moving.
        entity.movement.zeroMovement();

        // Play a random knocked animation. Could figure out a way to make this more dynamic later.
        string[] animationNames = { "Knocked", "Knocked2", "Knocked3" };
        entity.animationController.PlayAnimation(animationNames[Random.Range(0, animationNames.Length)]);
    }

    public override void Exit()
    {
        base.Exit();
        entity.animator.applyRootMotion = false;
    }

    public override void Update()
    {
        if (entity.animationController.IsAnimationComplete() && entity.characterController.isGrounded)
        {
            stateMachine.ChangeState(entity.standUpState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}