using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [Header("ScriptableObject Data")] 
    public DialogueData dialogueDataSO;
    
    [Header("Dialogue Component")] 
    [SerializeField] private TextAsset story;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DialogueManager.Instance.EnterDialogueMode(story);
        }
    }
}
