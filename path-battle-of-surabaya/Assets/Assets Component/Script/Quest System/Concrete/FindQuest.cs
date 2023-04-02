using System;
using UnityEngine;

public class FindQuest : QuestBase
{
    [Header("Scriptable Object Component")]
    [SerializeField] private QuestData questDataSO;

    [Header("Object Component")]
    [SerializeField] private GameObject[] objTaskList;
    
    // Redundant
    // public Transform objTransform;
    // public float objRadius;
    // public LayerMask objLayer;
    // private Collider2D[] objCollider;

    private void Update()
    {
        QuestActivated();
        QuestManager.Instance.isQuestCompleted = isQuestCompleted;
    }

    public override void QuestActivated()
    {
        QuestManager.Instance.SetQuestInterface(questDataSO);
        isQuestCompleted = false;
    }

    public override void QuestCompleted()
    {
        isQuestCompleted = true;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        for (int i = 0; i < objTaskList.Length; i++)
        {
            if (objTaskList.Length != questDataSO.subTaskCount)
            {
                return;
            }
            
            if (col.gameObject == objTaskList[i])
            {
                QuestManager.Instance.SubQuestIndex++;
                col.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
                
                if (QuestManager.Instance.SubQuestIndex >= objTaskList.Length)
                {
                    Debug.Log("Completed");
                    QuestCompleted();
                }
            }
        }
    }

    // private void CheckObjectTask()
    // {
    //     objCollider = Physics2D.OverlapCircleAll(objTransform.position, objRadius, objLayer);
    //     foreach (var obj in objCollider)
    //     {
    //         for (int i = 0; i < objCollider.Length; i++)
    //         {
    //             if (objCollider[i] == objCollider[i])
    //             {
    //                 // QuestManager.Instance.SubQuestIndex++;
    //                 if (objCount == objCollider.Length)
    //                 {
    //                     QuestCompleted();
    //                 }
    //             }
    //         }
    //     }
    // }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawWireSphere(objTransform.position, objRadius);
    // }
    
    
}
    
   