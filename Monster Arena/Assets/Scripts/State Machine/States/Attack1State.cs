
using System;
using UnityEngine;

public class Attack1State : BaseState
{
    //TODO: Find a way to make this able to go into a different combos
    //One idea is to use the attack counter at between 0-9 for 1 set of combo attacks
    //then, for every other 10's it goes into a different combo string. All ending at 9.
    //EX. Combo 1 = 1, 2, 3, 9
    // Combo 2 = 10, 11, 12, 19
    // Combo 1 into Combo 2 = 1, 2, 12, 19
    private int attackCounter = 0;


    public Attack1State(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        attackCounter++;
        SetCombatVariables();
        entity.animator.applyRootMotion = true;
    }

    public override void Exit()
    {
        attackCounter = 0;
        entity.animator.applyRootMotion = false;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if ( entity.animationController.animationComplete)
        {
            stateMachine.ChangeState(entity.idleState);
        }
        //Checks if you can dodge as well since the timing is the same. 
        //If you can dodge, you can also go to the next attack.
        if (entity.combat.attackingPressed && entity.combat.canDodge)
        {
            attackCounter++;
            attackCounter = Math.Clamp(attackCounter, 1, entity.player.numberOfBasicAttacks);
            stateMachine.ChangeStateEventString($"Attack{attackCounter}");
            SetCombatVariables();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    
    private void SetCombatVariables()
    {
        entity.combat.attackingPressed = false;
    }
}