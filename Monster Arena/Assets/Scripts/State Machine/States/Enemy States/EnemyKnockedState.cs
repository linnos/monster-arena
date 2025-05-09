using UnityEngine;
using UnityEngine.UIElements;

public class EnemyKnockedState : EnemyBaseState
{
    public EnemyKnockedState(Boss entity, EnemyStateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();

        // Play a random knocked animation. Could figure out a way to make this more dynamic later.
        string[] animationNames = { "EnemyKnocked", "EnemyKnocked2", "EnemyKnocked3" };
        entity.animationController.PlayAnimation(animationNames[Random.Range(0, animationNames.Length)]);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (entity.animationController.IsAnimationComplete())
        {
            entity.ChangeToRandomState();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}