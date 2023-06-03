using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectArcManager : MonoBehaviour
{
    #region Variable

    [Header("Fade Component")]
    [SerializeField] private RectTransform sceneFader;
    [SerializeField] private GameObject[] arcPanel;

    #endregion
    

    #region MonoBehaviour Callbacks

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

    #endregion

    #region Tsukuyomi Methods

    private void StartFader()
    {
        sceneFader.gameObject.SetActive (true);

        LeanTween.alpha (sceneFader, 1, 0);
        LeanTween.alpha(sceneFader, 0, 0.5f).setOnComplete(() =>
        {
            sceneFader.gameObject.SetActive(false);
        });
    }

    #endregion
    
    #region Open Arc Panel
    
    private IEnumerator ArcPanel(int arcNumber)
    {
        yield return new WaitForSeconds(0.5f);
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
    
    public void SelectArcPanel(int arcNumber) => StartCoroutine(ArcPanel(arcNumber));

    #endregion

    #region Select Prologue Scene

    private IEnumerator PrologueScene(int prologueNumber)
    {
        yield return new WaitForSeconds(0.5f);
        switch (prologueNumber)
        {
            case 1:
                sceneFader.gameObject.SetActive (true);

                LeanTween.alpha (sceneFader, 0, 0);
                LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => 
                {
                    Invoke ("OpenPrologue1", 0.5f);
                });

                break;
            case 2:
                sceneFader.gameObject.SetActive (true);

                LeanTween.alpha (sceneFader, 0, 0);
                LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => 
                {
                    Invoke ("OpenPrologue2", 0.5f);
                });

                break;
            case 3:
                sceneFader.gameObject.SetActive (true);

                LeanTween.alpha (sceneFader, 0, 0);
                LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => 
                {
                    Invoke ("OpenPrologue3", 0.5f);
                });

                break;
            default:
                Debug.Log("Arc Number Not Found");
                break;
        }
    }
    
    private void OpenPrologue1() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    private void OpenPrologue2() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    private void OpenPrologue3() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    
    public void SelectPrologueScene(int prolougeNumber) => StartCoroutine(PrologueScene(prolougeNumber));

    #endregion

}