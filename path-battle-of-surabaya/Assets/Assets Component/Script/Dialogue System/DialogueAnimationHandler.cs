using UnityEngine;

public class DialogueAnimationHandler : MonoBehaviour
{
    public bool isDialoguePanelActive { get; private set; }

    public void DialoguePanelActive() => isDialoguePanelActive = true;
    public void DialoguePanelNonActive() => isDialoguePanelActive = false;

}
