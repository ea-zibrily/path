using UnityEngine;

public abstract class AttackStateBaseAbstract
{
    // Abstract Attack State Class

    protected AttackStateMethod attackStateMethod { get; private set; }
    private  string animBoolName;
    protected AttackStateManager attackManager { get; private set; }

    public AttackStateBaseAbstract(AttackStateManager attackManager, AttackStateMethod attackStateMethod, string animBoolName)
    {
        this.attackManager = attackManager;
        this.attackStateMethod = attackStateMethod;
        this.animBoolName = animBoolName;
    }

    public abstract void EnterState(AttackStateManager attackManager);
    public abstract void UpdateState(AttackStateManager attackManager);
    public abstract void ExitState(AttackStateManager attackManager);

}

