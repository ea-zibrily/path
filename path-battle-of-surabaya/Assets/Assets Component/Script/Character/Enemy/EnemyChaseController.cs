using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseController : MonoBehaviour
{
    [Header("Main Component")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject playerObject;
    private Transform playerTransform;

    [Header("Reference")] 
    private Animator myAnim;
    private PlayerMainController playerMainController;
    private RunAwayDetector runAwayDetector;
    private DialogueController dialogueController;

    #region MonoBehavior Callbacks

    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        
        playerTransform = playerObject.transform;
        playerMainController = playerObject.GetComponent<PlayerMainController>();
        
        runAwayDetector = GetComponentInChildren<RunAwayDetector>();
        
        dialogueController = GameObject.Find("DialogueController").GetComponent<DialogueController>();
    }
    
    private void Update()
    {
        EnemyIdleAnimation();
        
        if (!runAwayDetector.QuestObject.activeSelf)
        {
            return;
        }
        
        EnemyChaseAnimation();
        EnemyChase();
    }

    #endregion

    #region Tsukuyomi Methods

    private void EnemyChase()
    {
        playerMainController.normalSpeed = 3f;
        transform.position = Vector2.MoveTowards(transform.position, 
            playerTransform.position, moveSpeed * Time.deltaTime);
    }

    private void EnemyIdleAnimation()
    {
        myAnim.SetFloat("Horizontal", -1);
        myAnim.SetBool("isWalk", false);
    }
    
    private void EnemyChaseAnimation()
    {
        myAnim.SetFloat("Horizontal", playerTransform.position.x - transform.position.x);
        myAnim.SetFloat("Vertical", playerTransform.position.x - transform.position.x);
        myAnim.SetBool("isWalk", true);
    }

    public void EnemyChaseEnterDialogue() => dialogueController.EnterDialogue();

    #endregion

    
}