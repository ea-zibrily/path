using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateBase
{
    protected PlayerMainController PlayerMainController;
    protected AttackStateManager attackManager;
    protected AttackStateMethod attackStateMethod;

    protected float startTime;
    protected string animBoolName;
    protected bool isAnimationFinished;
    protected bool isExitingState;
    protected bool isCombatDone;

    public AttackStateBase(PlayerMainController playerMainController, AttackStateManager attackManager, AttackStateMethod attackStateMethod, string animBoolName)
    {
        this.PlayerMainController = playerMainController;
        this.attackManager = attackManager;
        this.attackStateMethod = attackStateMethod;
        this.animBoolName = animBoolName;
    }

    public virtual void EnterState()
    {
        DoChecks();
        // attackManager.myAnim.SetBool(animBoolName, true);
        startTime = Time.time;
        //Debug.Log(animBoolName);
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void ExitState()
    {
        // attackManager.myAnim.SetBool(animBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {
        if (isCombatDone)
        {
            attackStateMethod.SwitchState(attackManager.idleAttackState);
        }
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
    

}
