using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
//using UnityEngine.Windows;
using System.IO;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    
    public string playerName;
    public int highScore;
    
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
    
    public void AddPlayerName(string playerNameInput)
    {
        playerName = playerNameInput;
    }
    
    public void SetHighScore(int score)
    {
        highScore = score;
        Debug.Log("High Score "+highScore+" Set");
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    public string LoadHighScorePlayerNameFromJson()
    {
        string path = Application.persistentDataPath + "/playerName.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            Debug.Log("Player Name "+playerName+" Loaded from Json");
        }
        return playerName;
    }

    public void SaveHighScorePlayerNameToJson(string playerName_)
    {
        SaveData data = new SaveData();
        data.playerName = playerName_;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerName.json", json);
        Debug.Log("Player Name "+playerName_+" Saved to Json");
    }

    public void SaveHighScoreToJson(int score)
    {
        SaveData data = new SaveData();
        data.highScore = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/playerHighscore.json", json);
        Debug.Log(highScore+" Saved to Json");
        
    }
    
    public int LoadHighScoreFromJson()
    {
        string path = Application.persistentDataPath + "/playerHighscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            Debug.Log(highScore+" Loaded from Json");
        }
        return highScore;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    


}
