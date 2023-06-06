using UnityEngine;

public class RunAwayDetector : MonoBehaviour
{
    #region Variable
        
    [field: SerializeField] public bool isArea {get; private set;}
    [field: SerializeField] public GameObject QuestObject {get; private set;}
    private RunAwayGO runAwayGO;
        
    #endregion
            
    #region MonoBehaviour Callbacks
            
    private void Awake()
    {
        runAwayGO = QuestObject.GetComponent<RunAwayGO>();
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
        if (other.CompareTag("Player"))
        {
            isArea = true;
        }
    }
            
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isArea = false;
        }
    }
        
    #endregion
}