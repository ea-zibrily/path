using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TeleporterManager : MonoBehaviour
{
    [Header("Player Teleport Component")]
    [SerializeField] private Transform gateTransform;

    [Header("Reference")]
    public GameObject fadeTeleport;
    private Transform playerObj;
    private PlayerMainController playerController;
    private TeleporterEventHandler teleporterEventHandler;
    private AudioManager audioManager;

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
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMainController>();
        teleporterEventHandler = fadeTeleport.GetComponent<TeleporterEventHandler>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
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
        yield return new WaitForSeconds(1f);
        playerController.SetZeroVelocity();
        playerController.isTeleport = true;
        
        yield return new WaitForSeconds(0.4f);
        audioManager.Play(SoundEnum.SFX_Door);
        fadeTeleport.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        TeleportPlayer();
        playerController.isTeleport = false;
    }
    
    private void TeleportPlayer() => playerObj.position = gateTransform.position;
    private void InactiveFadeTeleport() => fadeTeleport.SetActive(false);
}
