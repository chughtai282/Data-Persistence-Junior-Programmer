using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGameManager : MonoBehaviour
{
    public static SaveGameManager Instance;

    public string playerName;
    public int currentScore=0;

    public int highScore = 0;
    public string highName;

    public int highScore2 = 0;
    public string highName2;

    public int highScore3 = 0;
    public string highName3;

    public int highScore4 = 0;
    public string highName4;

    public int highScore5 = 0;
    public string highName5;


    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGameData();

    }

    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string highName;

        public int highscore2;
        public string highName2;

        public int highscore3;
        public string highName3;

        public int highscore4;
        public string highName4;

        public int highscore5;
        public string highName5;
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();

        data.highscore = highScore;
        data.highName = highName;

        data.highscore2 = highScore2;
        data.highName2 = highName2;

        data.highscore3 = highScore3;
        data.highName3 = highName3;

        data.highscore4 = highScore4;
        data.highName4 = highName4;

        data.highscore5 = highScore5;
        data.highName5 = highName5;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/SaveFile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/SaveFile.json";
        if (File.Exists(path))
        {
            Debug.Log("File Loaded");
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highscore;
            highName = data.highName;

            highScore2 = data.highscore2;
            highName2 = data.highName2;

            highScore3 = data.highscore3;
            highName3 = data.highName3;

            highScore4 = data.highscore4;
            highName4 = data.highName4;

            highScore5 = data.highscore5;
            highName5 = data.highName5;
        }
    }

}
