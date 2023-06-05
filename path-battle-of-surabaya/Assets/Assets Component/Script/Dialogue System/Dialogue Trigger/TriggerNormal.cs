using UnityEngine;

public class TriggerNormal : MonoBehaviour
{ 
    public bool isWaitOnEnter;
    [SerializeField] private float waitTime;
    private DialogueController dialogueController;
    
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

    public void EnterDialogue() => dialogueController.EnterDialogue();
}