using UnityEngine;

public class TriggerQuestComplete : TriggerNormal
{
    [SerializeField] private FindOneObjectGO findOneObjectGo;
    
    private void Update()
    {
        QuestCompleteChecker();
    }

    private void QuestCompleteChecker()
    {
        if (findOneObjectGo.isQuestCompleted && !isDialogueEnter)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}