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
    public int timelinePlayingIndex;
    
    #endregion
    
    #region Etc
    
    private OpeningArcAnimationHandler openingArcAnimationHandler;
    private int storyIndex;

    #endregion
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (storyIndex < DialogueDataSO.StoryList.Length - 1)
            {
                DialogueManager.Instance.EnterDialogueMode(DialogueDataSO.StoryList[storyIndex]);
                storyIndex++;
            }
            else
            {
                DialogueManager.Instance.ExitDialogueMode();
            }
        }

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     if (DialogueManager.Instance.isDialogueActive)
        //     {
        //         if (isDialogueEnd)
        //         {
        //             if (storyIndex < dialogueDataSO.storyCount - 1)
        //             {
        //                 storyIndex++;
        //                 DialogueManager.Instance.EnterDialogueMode(dialogueDataSO.StoryList[storyIndex]);
        //             }
        //             else
        //             {
        //                 DialogueManager.Instance.ExitDialogueMode();
        //                 GameManager.Instance.SceneController(GameManager.NEXT_LEVEL);
        //             }
        //         }
        //         else
        //         {
        //             DialogueManager.Instance.DisplayAllText();
        //         }
        //     }
        // }
        
    }


}
