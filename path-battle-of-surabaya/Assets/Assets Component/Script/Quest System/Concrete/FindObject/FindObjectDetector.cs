using System;
using UnityEngine;

public class FindObjectDetector : MonoBehaviour
{
    #region Variable

    [field: SerializeField] public bool isArea {get; private set;}
    [SerializeField] private GameObject interactObject;
    [field: SerializeField] public GameObject QuestObject {get; private set;}
    private FindOneObjectGO findOneObjectGO;

    #endregion
    
    #region MonoBehaviour Callbacks
    
    private void Awake()
    {
        findOneObjectGO = QuestObject.GetComponent<FindOneObjectGO>();
    }

    private void Start()
    {
        interactObject.SetActive(false);
    }

    private void Update()
    {
        if (QuestObject.activeSelf)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    
    #endregion

    #region Collider Callbacks

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactObject.SetActive(true);
        if (other.CompareTag("Player"))
        {
            isArea = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        interactObject.SetActive(false);
        if (other.CompareTag("Player"))
        {
            isArea = false;
        }
    }

    #endregion
    
}