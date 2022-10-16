using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HighScoresManager : MonoBehaviour
{
    public static HighScoresManager Instance;
    // Start is called before the first frame update
    public int[] scores = new int[6];
    public string[] players = new string [6];

    

    private string tempString;
    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    

    // Update is called once per frame
    

    public void SortScore()
    {
        for (int j = 0; j <= 5; j++)
        {


            for (int i = 0; i <= 5; i++)
            {
                if (scores[j] > scores[i]) //Exchanging values of int and string
                {                    
                    scores[j] = scores[j] - scores[i];
                    scores[i] = scores[j] + scores[i];
                    scores[j] = scores[i] - scores[j];

                    tempString = players[j];
                    players[j] = players[i];
                    players[i] = tempString;
                }
            }
        }
    }

    

    public void AddNewHighScore()
    {
        scores[5] = SaveGameManager.Instance.currentScore;
        players[5] = SaveGameManager.Instance.playerName;
        SortScore();
        SaveScores();
    }

    public void SaveScores()
    {
        SaveGameManager.Instance.highScore = scores[0];
        SaveGameManager.Instance.highScore2 = scores[1];
        SaveGameManager.Instance.highScore3 = scores[2];
        SaveGameManager.Instance.highScore4 = scores[3];
        SaveGameManager.Instance.highScore5 = scores[4];

        SaveGameManager.Instance.highName = players[0];
        SaveGameManager.Instance.highName2 = players[1];
        SaveGameManager.Instance.highName3 = players[2];
        SaveGameManager.Instance.highName4 = players[3];
        SaveGameManager.Instance.highName5 = players[4];
       
    }

    public void LoadScores()
    {
        scores[0] = SaveGameManager.Instance.highScore;
        scores[1] = SaveGameManager.Instance.highScore2;
        scores[2] = SaveGameManager.Instance.highScore3;
        scores[3] = SaveGameManager.Instance.highScore4;
        scores[4] = SaveGameManager.Instance.highScore5;

        players[0] = SaveGameManager.Instance.highName;
        players[1] = SaveGameManager.Instance.highName2;
        players[2] = SaveGameManager.Instance.highName3;
        players[3] = SaveGameManager.Instance.highName4;
        players[4] = SaveGameManager.Instance.highName5;

        

        
    }

    
}
