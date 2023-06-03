using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractionBase : MonoBehaviour
{
    #region Variable

    [Header("Interaction Component")]
    public GameObject interactObject;
    public bool IsOnArea {get; set;}

    #endregion

    #region MonoBehaviour Callbacks

    public virtual void Awake() 
    {
        interactObject.SetActive(false);
    }
    
    public virtual void Start()
    {
        IsOnArea = false;
    }

    #endregion
    

    #region Collider Callbacks

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactObject.SetActive(true);
        if (other.CompareTag("Player"))
        {
            IsOnArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactObject.SetActive(false);
        if (other.CompareTag("Player"))
        {
            IsOnArea = false;
        }
    }

    #endregion
}