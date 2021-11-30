using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    [System.Serializable]
    class SaveData
    {
        public string userName;
        public int highScore;
    }

    public static DataManager Instance;
    public string userName;
    public string savedUserName;
    public int highScore;
    public int savedHighScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.userName = userName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            savedUserName = data.userName;
            savedHighScore = data.highScore;
        }
    }
}
