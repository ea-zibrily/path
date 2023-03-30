using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tsukuyomi.Weapons;

public class AttackIdleState : AttackStateBase
{
    // Concrete State

    public AttackIdleState(PlayerMain playerMain, AttackStateManager attackManager, AttackStateMethod attackStateMethod, string animBoolName) : base(playerMain, attackManager, attackStateMethod, animBoolName)
    {
        // AttackIdleState Class Constructor
    }

    public override void EnterState()
    {
        base.EnterState();

        isCombatDone = false;
    }

    public override void ExitState()
    {
        base.ExitState();
        
        Debug.Log("Exit attack idle state masbro");
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Input.GetMouseButtonDown(0))
        {
            attackStateMethod.SwitchState(attackManager.primaryAttackState);
        }

        if (Input.GetMouseButtonDown(1))
        {
            attackStateMethod.SwitchState(attackManager.secondaryAttackState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        //Debug.Log($"Fixed update masbro");
    }
}
