using UnityEngine;

public class RunAwayGO : QuestBase
{
    #region Variable
            
    private RunAwayDetector runAwayDetector;
            
    #endregion
            
    #region MonoBehaviour Callbacks
        
    public override void Awake()
    {
        base.Awake();
        runAwayDetector = GetComponentInParent<RunAwayDetector>();
    }
        
    private void Start()
    {
        isQuestCompleted = false;
    }
            
    private void Update()
    {
        QuestActivated();
        QuestController();
    }
        
    #endregion
        
    #region Tsukuyomi Quest Method
        
    public override void QuestActivated()
    {
        if (runAwayDetector.isArea)
        {
            QuestCompleted();
        }
    }
            
    public override void QuestCompleted()
    {
        isQuestCompleted = true;
        DialogueController.EnterDialogue();
        gameObject.SetActive(false);
    }
            
    private void QuestController()
    {
        if (isQuestCompleted)
        {
            QuestManager.Instance.CompleteQuestInterface(QuestDataSO);
        }
        else
        {
            QuestManager.Instance.ActiveQuestInterface(QuestDataSO);
        }
    }
        
    #endregion
            
}