using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoSingleton<GameManager>
{
    #region Scene Handler Component
    
    [Header("Scene Handler Component")]
    [SerializeField] private RectTransform sceneFader;

    #endregion
    
    #region Game Condition

    public const string NEXT_LEVEL = "NextLevel";
    public const string GAME_OVER = "GameOver";

    #endregion

    private void Start()
    {
        StartFader();
    }

    public void SceneMoveController(string gameCondition)
    {
        switch (gameCondition)
        {
            case GAME_OVER:
                OpenGameScene();
                break;
            case NEXT_LEVEL:
                OpenNextLevelScene();
                break;
            default:
                Debug.LogWarning("Game Conditionnya Gaada Kang");
                break;
        }
    }

    #region Scene Fader Component Method

    private void StartFader()
    {
        sceneFader.gameObject.SetActive (true);
        
        // ALPHA
        LeanTween.alpha (sceneFader, 1, 0);
        LeanTween.alpha (sceneFader, 0, 1f).setOnComplete (() => {
            sceneFader.gameObject.SetActive (false);
        });
        
        // // SCALE
        // LeanTween.scale (sceneFader, new Vector3 (1, 1, 1), 0);
        // LeanTween.scale (sceneFader, Vector3.zero, 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete (() => {
        //     sceneFader.gameObject.SetActive (false);
        // });
    }
    
    public void OpenMenuScene () 
    {
        sceneFader.gameObject.SetActive (true);
        
        // ALPHA
        LeanTween.alpha (sceneFader, 0, 0);
        LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => {
            SceneManager.LoadScene (0);
        });
        
        // SCALE
        // LeanTween.scale (sceneFader, Vector3.zero, 0f);
        // LeanTween.scale (sceneFader, new Vector3 (1, 1, 1), 0.5f).setEase (LeanTweenType.easeInOutQuad).setOnComplete (() => {
        //     SceneManager.LoadScene (0);
        // });
    }
    
    private void OpenGameScene()
    {
        sceneFader.gameObject.SetActive (true);
        
        // ALPHA
        LeanTween.alpha (sceneFader, 0, 0);
        LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => {
            // Example for little pause before laoding the next scene
            Invoke ("LoadGame", 0.5f);
        });
        
        // // SCALE
        // LeanTween.scale (sceneFader, Vector3.zero, 0f);
        // LeanTween.scale (sceneFader, new Vector3 (1, 1, 1), 0.5f).setEase
        //     (LeanTweenType.easeInOutQuad).setOnComplete (() => {
        //     // Example for little pause before laoding the next scene
        //     Invoke ("LoadGame", 0.5f);
        // });
    }
    private void OpenNextLevelScene()
    {
        sceneFader.gameObject.SetActive (true);
        
        // ALPHA
        LeanTween.alpha (sceneFader, 0, 0);
        LeanTween.alpha (sceneFader, 1, 1f).setOnComplete (() => {
            // Example for little pause before laoding the next scene
            Invoke ("LoadNextLevel", 0.5f);
        });
        
        // // SCALE
        // LeanTween.scale (sceneFader, Vector3.zero, 0f);
        // LeanTween.scale (sceneFader, new Vector3 (1, 1, 1), 0.5f).setEase
        //     (LeanTweenType.easeInOutQuad).setOnComplete (() => {
        //     // Example for little pause before laoding the next scene
        //     Invoke ("LoadGame", 0.5f);
        // });
    }
        
    private void LoadGame () => SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
    private void LoadNextLevel () => SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);

    #endregion

}
