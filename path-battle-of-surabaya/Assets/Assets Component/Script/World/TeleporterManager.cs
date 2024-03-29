using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterManager : MonoBehaviour
{
    [Header("Player Teleport Component")]
    [SerializeField] private float posX;
    [SerializeField] private float posY;
    public TeleportSelection teleportSelection;
    
    [Header("Reference")]
    public GameObject fadeTeleport;
    private Transform playerObj;
    private TeleporterEventHandler teleporterEventHandler;

    private void OnEnable()
    {
        teleporterEventHandler.OnFaderDone += InactiveFadeTeleport;
    }

    private void OnDisable()
    {
        teleporterEventHandler.OnFaderDone -= InactiveFadeTeleport;
    }

    private void Awake()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player").transform;
        teleporterEventHandler = fadeTeleport.GetComponent<TeleporterEventHandler>();
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
        yield return new WaitForSeconds(0.4f);
        fadeTeleport.SetActive(true);
        yield return new WaitForSeconds(1f);
        TeleportPlayer();
    }
    
    private void TeleportPlayer() => playerObj.position = new Vector2(posX, posY);
    private void InactiveFadeTeleport() => fadeTeleport.SetActive(false);
}
