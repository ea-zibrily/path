// using System;
// using UnityEngine;
//
// public class FindQuestManager : MonoBehaviour
// {
//     [Header("Scriptable Object Component")]
//     [SerializeField] private QuestData questDataSO;
//
//     [Header("Object Component")]
//     public Transform[] enemyTransform;
//     public float radius;
//     public LayerMask enemyLayer;
//     private Collider2D[] enemyCollider;
//
//     #region Reference
//     private GameObject playerObj;
//     public QuestEventHandler QuestEventHandlers { get; private set; }
//     public FindQuestOld findQuestOld { get; private set; }
//     #endregion
//
//     private void Awake()
//     {
//         playerObj = GameObject.FindGameObjectWithTag("Player");
//         QuestEventHandlers = new QuestEventHandler();
//         findQuestOld = new FindQuestOld(playerObj, questDataSO, QuestEventHandlers, enemyTransform, radius, enemyLayer);
//     }
//
//     private void Start()
//     {
//         // QuestEventHandlers.AssignQuest(findQuest);
//     }
// }