using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FindManyObject : QuestBase
{
    [Header("Object Component")]
    [SerializeField] private GameObject[] objectList;
    private bool isObjectRemainsOne;

    #region MonoBehaviour Method

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

    #region Tsukuyomi Method
    
    public override void QuestActivated()
    {
        if (!isObjectRemainsOne)
        {
            return;
        }
        
        EnterQuestDialogue();
    }

    public override void QuestCompleted()
    {
        isQuestCompleted = true;
        gameObject.SetActive(false);
    }
    
    private void QuestController()
    {
        if (isQuestCompleted)
        {
            // StartCoroutine(QuestManager.Instance.CompleteQuestInterface(QuestDataSO));
            QuestManager.Instance.CompleteQuestInterface(QuestDataSO);
        }
        else
        {
            // StartCoroutine(QuestManager.Instance.ActiveQuestInterface(QuestDataSO));
            QuestManager.Instance.ActiveQuestInterface(QuestDataSO);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        for (int i = 0; i < objectList.Length; i++)
        {
            if (objectList.Length != QuestDataSO.subTaskCount)
            {
                return;
            }
            
            if (collider.gameObject == objectList[i])
            {
                QuestManager.Instance.SubQuestIndex++;
                collider.gameObject.GetComponentInChildren<Collider2D>().enabled = false;
                
                isObjectRemainsOne = QuestManager.Instance.SubQuestIndex == objectList.Length - 1;
                if (QuestManager.Instance.SubQuestIndex >= objectList.Length)
                {
                    Debug.Log("Completed");
                    Invoke("QuestCompleted", 2f);
                }
            }
        }
    }

    #endregion

    #region Redundant Code
    
    // Some Variable
    // public Transform objTransform;
    // public float objRadius;
    // public LayerMask objLayer;
    // private Collider2D[] objCollider;
    
    // Some Method
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
    
    #endregion
    
}
    
   