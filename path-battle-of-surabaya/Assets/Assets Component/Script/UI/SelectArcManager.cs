using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectArcManager : MonoBehaviour
{
    [Header("Fade Component")]
    [SerializeField] private RectTransform sceneFader;
    [SerializeField] private GameObject[] arcPanel;

    private void Awake()
    {
        for (int i = 0; i < arcPanel.Length; i++)
        {
            arcPanel[i].SetActive(false);
        }
    }

    void Start()
    {
        StartFader();
    }
    
    private void StartFader()
    {
        sceneFader.gameObject.SetActive (true);

        LeanTween.alpha (sceneFader, 1, 0);
        LeanTween.alpha(sceneFader, 0, 0.5f).setOnComplete(() =>
        {
            sceneFader.gameObject.SetActive(false);
        });
    }

    #region Open Arc Panel

    public void OpenArcPanel(int arcNumber)
    {
        switch (arcNumber)
        {
            case 1:
                sceneFader.gameObject.SetActive (true);

                LeanTween.alpha (sceneFader, 0, 0);
                LeanTween.alpha (sceneFader, 1, 0.5f).setOnComplete (() => 
                {
                    Invoke ("OpenPrologue", 0.5f);
                });
                
                Invoke("StartFader", 1f);
                
                break;
            case 2:
                sceneFader.gameObject.SetActive (true);

                LeanTween.alpha (sceneFader, 0, 0);
                LeanTween.alpha (sceneFader, 1, 0.5f).setOnComplete (() => 
                {
                    Invoke ("OpenArc1", 0.5f);
                });
                
                Invoke("StartFader", 1f);
                
                break;
            case 3:
                sceneFader.gameObject.SetActive (true);

                LeanTween.alpha (sceneFader, 0, 0);
                LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => 
                {
                    Invoke ("OpenArc2", 0.5f);
                });
                
                Invoke("StartFader", 1f);
                
                break;
            case 4:
                sceneFader.gameObject.SetActive (true);

                LeanTween.alpha (sceneFader, 0, 0);
                LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => 
                {
                    Invoke ("OpenEpilogue", 0.5f);
                });
                
                Invoke("StartFader", 1f);
                
                break;
            default:
                Debug.Log("Arc Number Not Found");
                break;
        }
    }
    private void OpenPrologue() => arcPanel[0].SetActive(true);
    private void OpenArc1() => arcPanel[1].SetActive(true);
    private void OpenArc2() => arcPanel[2].SetActive(true);
    private void OpenEpilogue() => arcPanel[3].SetActive(true);

    #endregion

    #region Open Scene
    
    public void OpenNextScene()
    {
        sceneFader.gameObject.SetActive (true);
        
        // ALPHA
        LeanTween.alpha (sceneFader, 0, 0);
        LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => {
            // Example for little pause before laoding the next scene
            Invoke ("LoadNextLevel", 0.5f);
        });
    }
    private void LoadNextLevel () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    #endregion
    
}