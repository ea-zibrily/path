using UnityEngine;

public class AttackStateMethod
{
    public AttackStateBase currentState { get; private set; }

    public void Initialize(AttackStateBase startingState)
    {
        currentState = startingState;
        currentState.EnterState();
    }

    public void SwitchState(AttackStateBase newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }

    // public void Initialize(AttackStateBase startingState, AttackStateManager attackManager)
    // {
    //     currentState = startingState;
    //     currentState.EnterState();
    // }

    // // public void UpdateInitialize(AttackStateManager attackManager)
    // // {
    // //     //currentState.UpdateState(attackManager);
    // // }

    // public void SwitchState(AttackStateBase newState, AttackStateManager attackManager)
    // {
    //     currentState.ExitState();
    //     currentState = newState;
    //     currentState.EnterState();
    // }
}