using UnityEngine;
using Tsukuyomi.Weapons;

public class AttackMainState : AttackStateBase
{
    // Concrete State

    private WeaponBase weaponBase;

    public AttackMainState(PlayerMain playerMain, AttackStateManager attackManager, AttackStateMethod attackStateMethod, string animBoolName, WeaponBase weaponBase) : base(playerMain, attackManager, attackStateMethod, animBoolName)
    {
        this.weaponBase = weaponBase;
        weaponBase.OnExit += ExitHandler;
    }

    public override void EnterState()
    {
        base.EnterState();

        //manggil enter method di func weaponBase
        playerMain.isPlayerAttack = true;
        attackManager.myAnim.SetBool("isAttack", true);
        weaponBase.WeaponEnter();
    }

    public override void ExitState()
    {
        base.ExitState();
        Debug.Log($"Pindah State Dulu Lur");
    }

    public void ExitHandler()
    {
        AnimationFinishTrigger();
        isCombatDone = true;
        playerMain.isPlayerAttack = false;
        attackManager.myAnim.SetBool("isAttack", false);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
    
}

