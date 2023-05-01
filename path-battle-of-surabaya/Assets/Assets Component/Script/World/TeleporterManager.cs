using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterManager : MonoBehaviour
{
    [Header("Player Teleport Component")]
    [SerializeField] private float posX;
    [SerializeField] private float posY;
    private float teleportDelay;
    public TeleportSelection teleportSelection;
    
    [Header("Reference")]
    public GameObject fadeTeleport;
    private GameObject playerObj;
    private TeleporterEventHandler teleporterEventHandler;

    private void OnEnable()
    {
        teleporterEventHandler.OnTeleportEnter += TeleportPlayer;
        teleporterEventHandler.OnFaderDone += InactiveFadeTeleport;
    }

    private void OnDisable()
    {
        teleporterEventHandler.OnTeleportEnter -= TeleportPlayer;
        teleporterEventHandler.OnFaderDone -= InactiveFadeTeleport;
    }

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        teleporterEventHandler = fadeTeleport.GetComponent<TeleporterEventHandler>();
        teleportDelay = 0.4f;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Teleport());
        }
    }
    
    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(teleportDelay);
        fadeTeleport.SetActive(true);
    }
    
    private void TeleportPlayer() => playerObj.transform.position = new Vector2(posX, posY);
    private void InactiveFadeTeleport() => fadeTeleport.SetActive(false);
}
