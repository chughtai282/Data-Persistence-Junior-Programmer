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
        SaveGameManager.Instance.SaveGameData();
    }


}
