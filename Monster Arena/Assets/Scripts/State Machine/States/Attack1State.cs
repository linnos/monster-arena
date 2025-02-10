
using System;
using UnityEngine;

public class Attack1State : BaseState
{
    //TODO: Need to find a way to decouple this from the combat class.
    private int attackCounter = 0;
    public Attack1State(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        attackCounter++;
        
        // entity.animator.Play($"Attack{attackCounter}");
        entity.combat.attackingPressed = false;
    }

    public override void Exit()
    {
        entity.animationComplete = false;
        attackCounter = 0;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (entity.animationComplete)
        {
            stateMachine.ChangeState(entity.idleState);
        }
        if (entity.combat.attackingPressed)
        {
            attackCounter++;
            attackCounter = Math.Clamp(attackCounter, 1, entity.player.numberOfBasicAttacks);
            stateMachine.ChangeStateEventString($"Attack{attackCounter}");
            // entity.animator.Play($"Attack{attackCounter}");
            entity.combat.attackingPressed = false;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}