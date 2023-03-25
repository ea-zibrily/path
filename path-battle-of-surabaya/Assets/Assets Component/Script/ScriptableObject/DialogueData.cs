using System;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName = "Dialogue Data", menuName = "ScriptableObject Data/Dialogue/New Dialogue Data", order = 2)]
public class DialogueData : ScriptableObject
{
    [Header("General")] 
    public string characterName;
    public CharacterRole characterRole;
    
    [Header("Main Component")]
    public int storyCount;
    [field: SerializeField] public TextAsset[] StoryList { get; private set; }

}
