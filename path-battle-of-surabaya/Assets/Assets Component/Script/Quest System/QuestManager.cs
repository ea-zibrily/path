using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class QuestManager : MonoSingleton<QuestManager>
{
    #region Quest Main Component

    public List<GameObject> questList;
    public int SubQuestIndex {get; set;}

    #endregion
    
    #region Quest User Interface Component   
    
    [Header("Quest UI Component")]
    public GameObject questPanel;
    public GameObject subQuestPanel;
    public TextMeshProUGUI questNumberText;
    public TextMeshProUGUI questDescriptionText;
    public TextMeshProUGUI subQuestCountText;

    #endregion

    #region Reference

    private Animator questAnimator;
    private Animator subQuestAnimator;

    #endregion

    protected override void Awake()
    {
        base.Awake();
        SubQuestIndex = 0;
        questAnimator = questPanel.GetComponent<Animator>();
        subQuestAnimator = subQuestPanel.GetComponent<Animator>();
    }
    
    public void EnterQuest(int questIndex)
    {
        questList[questIndex].gameObject.SetActive(true);
    }

    public void ActiveQuestInterface(QuestData questData)
    {
        questPanel.SetActive(true);
        questAnimator.Play("QuestOpening");
        questNumberText.text = questData.questNumber.ToString();
        questDescriptionText.text = questData.questName;
        
        if (questData.isTaskMoreThanOne)
        {
            subQuestPanel.SetActive(true);
            subQuestAnimator.Play("SubQuestOpening");
            subQuestCountText.text = SubQuestIndex + "/" + questData.subTaskCount;
        }
        else
        {
            subQuestPanel.SetActive(false);
            subQuestCountText.text = "";
        }
    }
    
    public void CompleteQuestInterface(QuestData questData)
    {
        questAnimator.Play("QuestClosing");
        questPanel.SetActive(false);

        if (questData.isTaskMoreThanOne)
        {
            subQuestAnimator.Play("SubQuestClosing");
            subQuestPanel.SetActive(false);
        }
    }
    

}

