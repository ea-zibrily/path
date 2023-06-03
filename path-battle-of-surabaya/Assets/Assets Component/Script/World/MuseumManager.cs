using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuseumManager : MonoBehaviour
{
    [Header("Player Teleport Component")]
    private Transform gateTransform;

    [Header("UI Component")] 
    public TextMeshProUGUI floorNumberUI;
    [SerializeField] private int floorNumber;

    [Header("Reference")]
    public GameObject fadeTeleport;
    private Transform playerObj;
    private PlayerMainController playerController;
    private TeleporterEventHandler teleporterEventHandler;
    [SerializeField] private GameObject panelObject;
    private Animator panelAnimator;

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
        panelAnimator = panelObject.GetComponent<Animator>();
    }

    private void Start()
    {
        floorNumberUI.text = " ";
    }

    private void Update()
    {
        floorNumberUI.text = floorNumber.ToString();
    }

    public IEnumerator Teleport()
    {
        panelAnimator.SetBool("isOpen", false);
        playerController.SetZeroVelocity();
        playerController.isTeleport = true;
        
        yield return new WaitForSeconds(0.4f);
        fadeTeleport.SetActive(true);
        
        yield return new WaitForSeconds(1f);
        TeleportPlayer();
        playerController.isTeleport = false;
        panelObject.SetActive(false);
    }
    
    private void TeleportPlayer() => playerObj.position = gateTransform.position;
    private void InactiveFadeTeleport() => fadeTeleport.SetActive(false);
    
    public void SetGateTransfrom(Transform newGate) => gateTransform = newGate;
    public void GoTeleport() => StartCoroutine(Teleport());
    public void SetFloorNumber(int newFloorNumber) => floorNumber = newFloorNumber;

}