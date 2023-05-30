using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public TextAsset dialogueAsset;
    public GameObject interactObject;
    private bool isOnArea;

    private void Awake()
    {
        interactObject.SetActive(false);
    }

    private void Start()
    {
        isOnArea = false;
    }

    private void Update()
    {
        if (isOnArea && Input.GetKeyDown(KeyCode.E))
        {
            interactObject.SetActive(false);
            DialogueManager.Instance.EnterDialogueMode(dialogueAsset);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        interactObject.SetActive(true);
        if (other.CompareTag("Player"))
        {
            isOnArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        interactObject.SetActive(false);
        isOnArea = false;
    }
}
