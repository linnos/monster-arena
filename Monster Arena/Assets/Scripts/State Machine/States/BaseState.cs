
using System;

public class BaseState : IState
{
    protected Player entity;
    protected StateMachineManager stateMachine;

    public BaseState(Player entity, StateMachineManager stateMachine){
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