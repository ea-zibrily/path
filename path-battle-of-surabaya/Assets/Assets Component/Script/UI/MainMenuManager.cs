using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Reference")] 
    public GameObject creditPanel;
    public GameObject settingsPanel;

    private void Start()
    {
        creditPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void StartGame() => GameManager.Instance.SceneMoveController(SceneEnum.NextScene);
    public void QuitGame() => Debug.Log("Quit masze");
    public void OpenCredit() => creditPanel.SetActive(true);
    public void OpenSettings() => settingsPanel.SetActive(true);
    
}
