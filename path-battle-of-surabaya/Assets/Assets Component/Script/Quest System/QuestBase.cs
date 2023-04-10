using System;
using UnityEngine;

public abstract class QuestBase : MonoBehaviour
{
    #region ScriptableObject

    [field: SerializeField] public QuestData QuestDataSO { get; private set; }
    public DialogueController DialogueController { get; private set; }

    #endregion

    #region Etc
    
    public bool isQuestCompleted { get; set; }
    private int storyIndex;
    
    #endregion

    private void Awake()
    {
        storyIndex = 0;
        DialogueController = GameObject.Find("DialogueController").GetComponent<DialogueController>();
    }

    public abstract void QuestActivated();
    public abstract void QuestCompleted();
    
    public void EnterQuestDialogue()
    {
        if (storyIndex <= QuestDataSO.questDialogue.Length - 1)
        {
            DialogueManager.Instance.EnterDialogueMode(QuestDataSO.questDialogue[storyIndex]);
            storyIndex++;
        }
    }

}
