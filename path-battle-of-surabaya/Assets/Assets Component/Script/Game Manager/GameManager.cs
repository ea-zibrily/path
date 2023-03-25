using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const string NEXT_LEVEL = "NextLevel";
    public const string GAME_OVER = "GameOver";

    public void SceneController(string gameCondition)
    {
        switch (gameCondition)
        {
            case NEXT_LEVEL:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case GAME_OVER:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            default:
                Debug.LogWarning("Game Condition Not Found");
                break;
        }
    }
}
