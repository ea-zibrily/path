using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class QuestManager : MonoSingleton<QuestManager>
{
    public GameObject[] questList;
    
    public TextMeshProUGUI questNameText;
    public TextMeshProUGUI subQuestCountText;
    [field: SerializeField] public int SubQuestIndex {get; set;}
    public bool isQuestCompleted {get; set;}

    // public void EnterQuest(int questIndex)
    // {
    //     questList[questIndex].gameObject.SetActive(true);
    // }

    public void SetQuestInterface(QuestData questData)
    {
        questNameText.text = questData.questName;
        
        if (questData.isTaskMoreThanOne)
        {
            subQuestCountText.text = SubQuestIndex + "/" + questData.subTaskCount;
        }
        else
        {
            subQuestCountText.text = "";
        }
        
        // bool isComplete = ((questNameText.fontStyle & FontStyles.Strikethrough) != 0);
        //
        // if (isComplete)
        // {
        //     questNameText.fontStyle = FontStyles.Strikethrough;
        // }
        // else
        // {
        //     questNameText.fontStyle = FontStyles.Normal;
        // }
    }
   
}

