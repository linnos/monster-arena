using UnityEngine;
using UnityEngine.UIElements;

public class EnemyIdleState : EnemyBaseState
{
    private float idleTime = 0;
    public EnemyIdleState(Boss entity, EnemyStateMachineManager stateMachine) : base(entity, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        // Play a random knocked animation. Could figure out a way to make this more dynamic later.
        string[] animationNames = { "EnemyIdle", "EnemyIdle2" };
        entity.animationController.PlayAnimation(animationNames[Random.Range(0, animationNames.Length)]);
        idleTime = Random.Range(3, 8);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(idleTime <= 0)
        {
            entity.ChangeToRandomState();
        }
        else
        {
            idleTime -= Time.deltaTime;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}