
using System;

public class EnemyBaseState : IState
{
    protected Boss entity;
    protected EnemyStateMachineManager stateMachine;

    public EnemyBaseState(Boss entity, EnemyStateMachineManager stateMachine){
        this.entity = entity;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void PhysicsUpdate() {}
}