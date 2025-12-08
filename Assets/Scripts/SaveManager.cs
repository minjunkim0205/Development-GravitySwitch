using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    private string savePath;

    [System.Serializable]
    public class SaveData
    {
        public bool level1Clear;
        public bool level2Clear;
        public bool level3Clear;
        public bool level4Clear;
        public bool level5Clear;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        savePath = Application.persistentDataPath + "/save.json";
    }

    public SaveData Load()
    {
        if (!File.Exists(savePath))
        {
            SaveData newData = new SaveData();
            File.WriteAllText(savePath, JsonUtility.ToJson(newData, true));
            return newData;
        }

        string json = File.ReadAllText(savePath);
        return JsonUtility.FromJson<SaveData>(json);
    }

    public void SaveLevelClear(int level)
    {
        SaveData data = Load();

        switch (level)
        {
            case 1: data.level1Clear = true; break;
            case 2: data.level2Clear = true; break;
            case 3: data.level3Clear = true; break;
            case 4: data.level4Clear = true; break;
            case 5: data.level5Clear = true; break;
        }

        File.WriteAllText(savePath, JsonUtility.ToJson(data, true));
    }
}
