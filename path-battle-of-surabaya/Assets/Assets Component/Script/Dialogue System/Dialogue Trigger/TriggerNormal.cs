using System;
using UnityEngine;

public class TriggerNormal : MonoBehaviour
{ 
    public bool isWaitOnEnter;
    public bool isDialogueEnter {get; private set;}
    [SerializeField] private float waitTime;
    private DialogueController dialogueController;
    
    private void Awake()
    {
        dialogueController = GameObject.Find("DialogueController").GetComponent<DialogueController>();
    }

    private void Start()
    {
        isDialogueEnter = false;
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
        
        isDialogueEnter = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void EnterDialogue() => dialogueController.EnterDialogue();
}