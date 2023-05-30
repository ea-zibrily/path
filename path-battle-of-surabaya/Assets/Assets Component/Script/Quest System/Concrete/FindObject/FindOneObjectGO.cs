using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FindOneObjectGO : QuestBase
{
    #region Variable
    
    private FindObjectDetector findObjectDetector;
    
    #endregion
    
    #region MonoBehaviour Callbacks

    public override void Awake()
    {
        base.Awake();
        findObjectDetector = GetComponentInParent<FindObjectDetector>();
    }

    private void Start()
    {
        isQuestCompleted = false;
    }
    
    private void Update()
    {
        QuestActivated();
        QuestController();
    }

    #endregion

    #region Tsukuyomi Quest Method

    public override void QuestActivated()
    {
        if (Input.GetKeyDown(KeyCode.E) && findObjectDetector.isArea)
        {
            QuestCompleted();
        }
    }
    
    public override void QuestCompleted()
    {
        isQuestCompleted = true;
        DialogueController.EnterDialogue();
        gameObject.SetActive(false);
    }
    
    private void QuestController()
    {
        if (isQuestCompleted)
        {
            QuestManager.Instance.CompleteQuestInterface(QuestDataSO);
        }
        else
        {
            QuestManager.Instance.ActiveQuestInterface(QuestDataSO);
        }
    }

    #endregion
    
   
}