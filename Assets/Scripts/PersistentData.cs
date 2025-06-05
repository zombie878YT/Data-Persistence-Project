using System.IO;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Instance;
    public string playerName;
    public string highScorePlayer;
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

        Load();
    }

    [System.Serializable]

    class SaveData
    {
        public string playerName;
        public string highScorePlayer;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highScorePlayer = highScorePlayer;
        data.highScore = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScorePlayer = data.highScorePlayer;
            highScore = data.highScore;
        }
    }
}
