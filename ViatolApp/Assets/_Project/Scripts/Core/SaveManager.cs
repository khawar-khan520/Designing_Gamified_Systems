using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private string SavePath => Application.persistentDataPath + "/save.json";

    public PlayerData CurrentData { get; private set; }

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        CurrentData = Load();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(CurrentData, true);
        File.WriteAllText(SavePath, json);
        Debug.Log("[SaveManager] Saved to: " + SavePath);
    }

    public PlayerData Load()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            Debug.Log("[SaveManager] Loaded save file.");
            return JsonUtility.FromJson<PlayerData>(json);
        }
        Debug.Log("[SaveManager] No save found, creating default.");
        return CreateDefaultData();
    }

    public void ResetSave()
    {
        if (File.Exists(SavePath)) File.Delete(SavePath);
        CurrentData = CreateDefaultData();
        Save();
        Debug.Log("[SaveManager] Save reset.");
    }

    private PlayerData CreateDefaultData()
    {
        return new PlayerData
        {
            profile = new PlayerProfile
            {
                profileId = System.Guid.NewGuid().ToString(),
                playerName = "Player"
            },
            progress = new ProgressData(),
            rewards = new RewardData(),
            story = new StoryData()
        };
    }
}
