using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkerEventHandler : MonoBehaviour
{
    private DialogueController dialogueController;
    
    private void Awake()
    {
        dialogueController = GameObject.Find("DialogueController").GetComponent<DialogueController>();
    }
    
    public void DarkerEnterDialogue() => dialogueController.EnterDialogue();
    public void DarkerToMainMenu() => GameManager.Instance.SceneMoveController(SceneEnum.MainMenu);
}