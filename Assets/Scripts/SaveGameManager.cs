using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveGameManager : MonoBehaviour
{
    public static SaveGameManager Instance;
    public string playerName;
    public int highScore = 0;
    public string highName;


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
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        data.highscore = highScore;
        data.highName = highName;
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
        }
    }

}
