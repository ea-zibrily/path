using UnityEngine;

public abstract class QuestBase : MonoBehaviour
{
    public bool isQuestCompleted { get; set; }
    
    public abstract void QuestActivated();
    public abstract void QuestCompleted();

}
