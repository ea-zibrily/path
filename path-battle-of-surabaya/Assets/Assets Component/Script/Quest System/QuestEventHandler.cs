using System;
using UnityEngine;

public class QuestEventHandler
{
    public event Action<QuestBaseOld> OnQuestActive;
    public event Action<QuestBaseOld> OnQuestCompleted;
    
    public void AssignQuest(QuestBaseOld questBaseOld)
    {
        OnQuestActive?.Invoke(questBaseOld);
    }
    
    public void CompletedQuest(QuestBaseOld questBaseOld)
    {
        OnQuestCompleted?.Invoke(questBaseOld);
    }
}
