using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    #region Dialogue Parameters

    [Header("Parameters Component")]
    [SerializeField] private float textSpeed;
    private Coroutine displayLineCoroutine;

    #endregion
    
    #region Dialogue UI Component
    
    [Header("Dialogue UI Component")] 
    [SerializeField] private TextMeshProUGUI characterNameTextUI;
    [SerializeField] private TextMeshProUGUI conversationTextUI;
    [SerializeField] private GameObject textBoxPanel;
    [SerializeField] private GameObject continueObj;
    public bool isDialogueActive { get; private set; }

    #endregion
    
    #region Dialogue Component

    private Story currentStory;
    private bool isDialogueEnd;

    #endregion

    #region Dialogue SoundEffect
    
    private AudioSource myAudio;

    #endregion
    
    #region Dialogue Tag
   
    private const string SPEAKER_TAG = "speaker";
    private const string POTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string ANIMATION_TAG = "animation";

    #endregion

    #region Reference
    
    [Header("Reference")]
    [SerializeField] private Animator characterPanelAnimator;
    private DialogueAnimationHandler dialogueAnimationHandler;
    private Animator dialoguePanelAnimator;

    #endregion
    
    protected override void Awake()
    {
        dialoguePanelAnimator = textBoxPanel.GetComponent<Animator>();
        dialogueAnimationHandler = textBoxPanel.GetComponent<DialogueAnimationHandler>();
        myAudio = GetComponent<AudioSource>();
    }
    
    private void Start()
    {
        isDialogueActive = false;
        textBoxPanel.SetActive(false);
    }

    private void Update()
    {
        if (!isDialogueActive)
        {
            return;
        }

        if (isDialogueEnd && Input.GetKeyDown(KeyCode.Space))
        {
            ContinueDialogue();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (var tag in currentTags)
        {
            string[] tagSplit = tag.Split(':');
            if (tagSplit.Length != 2)
            {
                Debug.LogError($"Tagnya salah kang: {tag}");
            }
            
            string tagType = tagSplit[0].Trim();
            string tagValue = tagSplit[1].Trim();

            switch (tagType)
            {
                case SPEAKER_TAG:
                    characterNameTextUI.text = tagValue;
                    break;
                case POTRAIT_TAG:
                    characterPanelAnimator.Play(tagValue);
                    break;
                case LAYOUT_TAG:
                    dialoguePanelAnimator.Play(tagValue);
                    break;
                case ANIMATION_TAG:
                    characterPanelAnimator.Play(tagValue);
                    break;
                default:
                    Debug.Log("Tagnya gaada kang");
                    break;
            }
        }
    }
    
    public void EnterDialogueMode(TextAsset inkJSONText)
    {
        currentStory = new Story(inkJSONText.text);
        isDialogueActive = true;
        textBoxPanel.SetActive(true);

        //reset
        characterNameTextUI.text = "";
        characterPanelAnimator.Play("empty");
        dialoguePanelAnimator.Play("left");
        
        ContinueDialogue();
    }
    
    public IEnumerator ExitDialogueMode()
    {
        dialoguePanelAnimator.Play("closing");
        yield return new WaitForSeconds(0.2f);

        isDialogueActive = false;
        textBoxPanel.SetActive(false);
        conversationTextUI.text = "";
    }
    
    private void ContinueDialogue()
    {
        if (currentStory.canContinue)
        {
            if (!isDialogueActive)
            {
                return;
            }
            
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    
    private IEnumerator DisplayLine(string newLine)
    {
        bool isAddingRichTextTag = false;

        //empty dialogue text
        conversationTextUI.text = "";
        isDialogueEnd = false;
        continueObj.SetActive(false);
        
        //display each letter one at the time
        foreach (var letter in newLine.ToCharArray())
        {
            //add rich text tag 
            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                conversationTextUI.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            else
            {
                conversationTextUI.text += letter;
                myAudio.Play();
                yield return new WaitForSeconds(textSpeed);
            }
        }

        continueObj.SetActive(true);
        isDialogueEnd = true;
    }

}
