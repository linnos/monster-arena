using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttack1State : EnemyBaseState
{
    public EnemyAttack1State(Boss entity, EnemyStateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        // Play a random knocked animation. Could figure out a way to make this more dynamic later.
        string[] animationNames = { "EnemyAttack1", "EnemyAttack2" };
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