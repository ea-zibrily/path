using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.Playables;

public class DialogueController : MonoBehaviour
{
    #region ScriptableObject Component
    
    [field: SerializeField] public DialogueData DialogueDataSO {get; private set;}

    #endregion
    
    #region Timeline Component

    [Serializable]
    public class TimelineLists
    {
        public string timelineName;
        public PlayableDirector playableDirector;
    }
    
    [field: SerializeField] public TimelineLists[] TimelineList { get; private set; }
    [HideInInspector] public int timelinePlayingIndex;
    
    #endregion

    #region Etc
    
    private int storyIndex;
    private bool isDialogueFirstActive;
    [HideInInspector] public bool isStoryEnd;
    private OpeningArcAnimationHandler openingArcAnimationHandler;

    #endregion
    
    private void Start()
    {
        storyIndex = 0;
        isDialogueFirstActive = DialogueDataSO.isDialogueOnFirstTime;
        isStoryEnd = false;
    }

    void Update()
    {
        if (!DialogueDataSO.isDialogueOnFirstTime)
        {
            return;
        }

        if (isDialogueFirstActive)
        {
            Invoke("EnterDialogue", DialogueDataSO.invokeDelay);
            isDialogueFirstActive = false;
        }
    }

    public void EnterDialogue()
    {
        if (storyIndex <= DialogueDataSO.StoryList.Length - 1)
        {
            DialogueManager.Instance.EnterDialogueMode(DialogueDataSO.StoryList[storyIndex]);
            storyIndex++;
        }
        else
        {
            DialogueManager.Instance.ExitDialogueMode();
        }
    }
}
