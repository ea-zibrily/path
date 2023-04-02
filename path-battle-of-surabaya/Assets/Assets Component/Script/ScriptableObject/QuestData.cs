using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quest Data", menuName = "ScriptableObject Data/Quest/New Quest Data", order = 4)]
public class QuestData : ScriptableObject
{
    [Header("General")]
    public string questName;
    public string questId;
    [TextArea(3, 10)] public string questDescription;
    public QuestCondition questType;
    public bool isTaskMoreThanOne;
    public int subTaskCount;

    [Header("Reward n Goal")]
    public int questReward;
    public int questGoal;

}
