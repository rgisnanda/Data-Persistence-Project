using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistence : MonoBehaviour
{
    public static DataPersistence Instance;

    public string playerName;
    public string bestPlayerName;
    public int bestScore;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            loadData();
        }
        else
            Destroy(gameObject);
    }

    [System.Serializable]
    public class GameData
    {
        public string playerName;
        public string bestPlayerName;
        public int bestScore;
    }

    public void saveData()
    {
        GameData data = new GameData();
        data.playerName = playerName;
        data.bestPlayerName = bestPlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void loadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);

            playerName = data.playerName;
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }

    }
}
