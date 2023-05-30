using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindOneObject : QuestBase
{
    [Header("Main Component")]
    [SerializeField] private Transform objTransform;
    [SerializeField] private float objRadius;
    [SerializeField] private LayerMask objLayer;
    private Collider2D[] objCollider;
    
    void Start()
    {
        isQuestCompleted = false;
    }
    
    void Update()
    {
        QuestActivated();
        QuestController();
    }
    
    public override void QuestActivated()
    {
        CheckObjectTask();
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
    
    private void CheckObjectTask()
    {
        objCollider = Physics2D.OverlapCircleAll(objTransform.position, objRadius, objLayer);
        
        foreach (var obj in objCollider)
        {
            QuestCompleted();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(objTransform.position, objRadius);
    }
}
