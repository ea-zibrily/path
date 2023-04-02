using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class QuestBaseOld
{
    protected GameObject playerObj;

    protected string QuestName;
    protected string questId;
    protected QuestEventHandler QuestEvent;
    protected QuestCondition questCondition;
    
    //Constructor
    public QuestBaseOld(GameObject playerObj, QuestData questData, QuestEventHandler questEvent)
    {
        this.playerObj = playerObj;
        this.QuestName = questData.questName;
        this.questId = questData.questId;
        this.questCondition = questData.questType;
        this.QuestEvent = questEvent;
    }
    
    protected virtual void OnEnable()
    {
        QuestEvent.OnQuestActive += QuestEventActive;
        QuestEvent.OnQuestCompleted += QuestEventCompleted;

        if (questCondition == QuestCondition.Active)
        {
            QuestActivated();
        }
    }
    
    protected virtual void OnDisable()
    {
        QuestEvent.OnQuestActive -= QuestEventActive;
        QuestEvent.OnQuestCompleted -= QuestEventCompleted;
    }
    
    private void QuestEventActive(QuestBaseOld questBaseOld)
    {
        if (questBaseOld.questId != questId)
        {
            return;
        }

        questCondition = QuestCondition.Active;
        QuestActivated();
    }
    
    private void QuestEventCompleted(QuestBaseOld questBaseOld)
    {
        if (questBaseOld.questId != questId)
        {
            return;
        }

        questCondition = QuestCondition.Completed;
        QuestCompleted();
    }
    
    public abstract void QuestActivated();
    public abstract void QuestCompleted();
    
    protected void CompleteQuest()
    {
        QuestEvent.CompletedQuest(this);
    }
    
}
