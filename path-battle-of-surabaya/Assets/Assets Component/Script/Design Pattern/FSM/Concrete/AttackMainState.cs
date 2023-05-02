using UnityEngine;
using Tsukuyomi.Weapons;

public class AttackMainState : AttackStateBase
{
    // Concrete State

    private WeaponBase weaponBase;

    public AttackMainState(PlayerMainController playerMainController, AttackStateManager attackManager, AttackStateMethod attackStateMethod, string animBoolName, WeaponBase weaponBase) : base(playerMainController, attackManager, attackStateMethod, animBoolName)
    {
        this.weaponBase = weaponBase;
        weaponBase.OnExit += ExitHandler;
    }

    public override void EnterState()
    {
        base.EnterState();

        //manggil enter method di func weaponBase
        PlayerMainController.isPlayerAttack = true;
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
        PlayerMainController.isPlayerAttack = false;
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

