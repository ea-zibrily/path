using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private DialogueController dialogueController;
    [SerializeField] private bool isWaitOnEnter;
    [SerializeField] private float waitTime;
    
    private void Awake()
    {
        dialogueController = GameObject.Find("DialogueController").GetComponent<DialogueController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.CompareTag("Player"))
        {
            return;
        }
        
        if (isWaitOnEnter)
        {
            Invoke("EnterDialogue", waitTime);
        }
        else
        {
            EnterDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
    
    private void EnterDialogue() => dialogueController.EnterDialogue();
}
