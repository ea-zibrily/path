using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PanelInteraction : InteractionBase
{
    [SerializeField] private GameObject panelObject;
    private Animator panelAnimator;

    #region MonoBehaviour Callbacks

    public override void Awake()
    {
        panelAnimator = panelObject.GetComponent<Animator>();
        panelObject.SetActive(false);
    }

    private void Update()
    {
       SetActivePanel();
    }

    #endregion
    
    #region Tsukuyomi Methods

    private void SetActivePanel()
    {
        // if (IsOnArea && Input.GetKeyDown(KeyCode.E))
        // {
        //     panelObject.SetActive(true);
        //     panelAnimator.SetBool("isOpen", true);
        //     interactObject.SetActive(false);
        // }
        
        if (IsOnArea)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                panelObject.SetActive(true);
                panelAnimator.SetBool("isOpen", true);
                interactObject.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                panelAnimator.SetBool("isOpen", false);
            }

        }

       
    }

    #endregion
}