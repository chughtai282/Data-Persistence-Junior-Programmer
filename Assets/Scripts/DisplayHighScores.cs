using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScores : MonoBehaviour
{
    public TMP_Text[] PlayerNames = new TMP_Text[5];
    public TMP_Text[] Highscore = new TMP_Text[5];
    void Start()
    {
        for (int i = 0;i<5;i++)
        {
            Highscore[i].text = HighScoresManager.Instance.scores[i].ToString();
            PlayerNames[i].text = HighScoresManager.Instance.players[i];
            if(Highscore[i].text == "0")
            {
                Destroy(Highscore[i].gameObject);
                Destroy(PlayerNames[i].gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
