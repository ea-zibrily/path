using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMuseumController : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float moveSpeed;

    private Transform playerTransform;
    private PlayerMainController playerMainController;
    private FindObjectDetector findObjectDetector;

    #region MonoBehavior Callbacks

    private void Awake()
    {
        playerTransform = playerObject.transform;
        playerMainController = playerObject.GetComponent<PlayerMainController>();
        
        findObjectDetector = GetComponentInChildren<FindObjectDetector>();
    }
    
    private void Update()
    {
        if (!findObjectDetector.QuestObject.activeSelf)
        {
            return;
        }
        
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

    #endregion

    
}