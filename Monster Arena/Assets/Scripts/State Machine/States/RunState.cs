using UnityEngine;

public class RunState : BaseState
{
    public RunState(Player entity, StateMachineManager stateMachine) : base(entity, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(!entity.staminaManager.UseStamina(entity.player.runStaminaCost * Time.deltaTime)){
            stateMachine.ChangeState(entity.walkState);
            return;
        }

        if(!entity.movement.isMoving){
            stateMachine.ChangeState(entity.idleState);
        }
        else if(!entity.movement.isRunning){
            stateMachine.ChangeState(entity.walkState);
        }
        else if(!entity.characterController.isGrounded){
            stateMachine.ChangeState(entity.jumpState);
        }
        else if(entity.combat.attackingPressed){
            stateMachine.ChangeState(entity.dashAttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}