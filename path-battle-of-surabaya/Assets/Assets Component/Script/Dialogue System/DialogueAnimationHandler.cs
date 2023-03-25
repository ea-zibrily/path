using System;
using UnityEngine;

public class DialogueAnimationHandler : MonoBehaviour
{
    public event Action OnDialoguePanelActive;
    public event Action OnDialoguePanelNonActive;

    public void DialoguePanelActive() => OnDialoguePanelActive?.Invoke();
    public void DialoguePanelNonActive() => OnDialoguePanelNonActive?.Invoke();

}
