using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    [Header("Reference")] 
    public GameObject creditPanel;

    private void Start()
    {
        FindObjectOfType<AudioManager>().Stop(SoundEnum.BGM_RuangManekin);
        FindObjectOfType<AudioManager>().Play(SoundEnum.BGM_MainMenu);
        creditPanel.SetActive(false);
    }
    

    public void StartGame() => GameManager.Instance.SceneMoveController(SceneEnum.NextScene);
    public void QuitGame() => Application.Quit();
    public void OpenCredit() => creditPanel.SetActive(true);
    
    public void ClickSound() => FindObjectOfType<AudioManager>().Play(SoundEnum.SFX_Clicked);

}
