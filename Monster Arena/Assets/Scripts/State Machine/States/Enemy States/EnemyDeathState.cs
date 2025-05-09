using UnityEngine;
using UnityEngine.UIElements;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(Boss entity, EnemyStateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        entity.audioSource.Stop();
        entity.audioSource.PlayOneShot(entity.victoryAudioSource);
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