using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_InputField nameEditField;

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveGameManager.Instance.playerName = nameEditField.text;
        
    }

   public void ExitGame()
    {
        HighScoresManager.Instance.SaveScores();
        SaveGameManager.Instance.SaveGameData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();        
#else
        Application.Quit();
#endif
    }

    public void ResetHighScore()
    {
        SaveGameManager.Instance.highScore = 0;
        SaveGameManager.Instance.highName = "";

        SaveGameManager.Instance.highScore2 = 0;
        SaveGameManager.Instance.highName2 = "";

        SaveGameManager.Instance.highScore3 = 0;
        SaveGameManager.Instance.highName3 = "";

        SaveGameManager.Instance.highScore4 = 0;
        SaveGameManager.Instance.highName4 = "";

        SaveGameManager.Instance.highScore5 = 0;
        SaveGameManager.Instance.highName5 = "";

        SaveGameManager.Instance.SaveGameData();
    }

    public void GoToHighScores()
    {
        
        HighScoresManager.Instance.LoadScores();
        HighScoresManager.Instance.SortScore();
        SceneManager.LoadScene("High Scores");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
