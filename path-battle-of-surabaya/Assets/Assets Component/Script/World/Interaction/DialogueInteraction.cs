using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteraction : InteractionBase
{
    public TextAsset dialogueAsset;

    #region MonoBehaviour Callbacks

    private void Update()
    {
       SetActiveDialogue();
    }

    #endregion

    #region Tsukuyomi Methods

    private void SetActiveDialogue()
    {
        if (IsOnArea && Input.GetKeyDown(KeyCode.E))
        {
            interactObject.SetActive(false);
            DialogueManager.Instance.EnterDialogueMode(dialogueAsset);
        }
    }

    #endregion
    
}
