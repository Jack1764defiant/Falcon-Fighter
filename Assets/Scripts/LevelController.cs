using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelController : MonoBehaviour
{
    public LoadScene[] levels;
    bool[] unlocked = new bool[12];

    public static LevelController instance;

    // Start is called before the first frame update
    void Awake()
    {
        string jsonImport;
        //Save();
        try
        {
            jsonImport = File.ReadAllText(Application.persistentDataPath + "/unlockedLevels.save");
        }
        catch
        {
            bool[] toSave = new bool[]
            {
                true, false, false, false, false, false, false, false, false,false, false, false
            };

            unlockedLevels levelsToSave = new unlockedLevels(toSave);
            string jsonExport = JsonUtility.ToJson(levelsToSave);

            File.WriteAllText(Application.persistentDataPath + "/unlockedLevels.save", jsonExport);
            jsonImport = File.ReadAllText(Application.persistentDataPath + "/unlockedLevels.save");
        }
        bool[] unlocked = JsonUtility.FromJson<unlockedLevels>(jsonImport).unlocked;
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].isUnlocked = unlocked[i];
        }
        instance = this;
    }
    public void Reset()
    {
        bool[] toSave = new bool[12]
        {
            true,false,false,false,false,false,false,false,false,false,false,false
        };
        unlockedLevels levelsToSave = new unlockedLevels(toSave);
        string jsonExport = JsonUtility.ToJson(levelsToSave);

        File.WriteAllText(Application.persistentDataPath + "/unlockedLevels.save", jsonExport);
    }
    public void UnlockAll()
    {
        bool[] toSave = new bool[12]
        {
            true,true,true,true,true,true,true,true,true,true,true,true
        };
        unlockedLevels levelsToSave = new unlockedLevels(toSave);
        string jsonExport = JsonUtility.ToJson(levelsToSave);

        File.WriteAllText(Application.persistentDataPath + "/unlockedLevels.save", jsonExport);
    }
    public void Save(int index)
    {
        string jsonImport = File.ReadAllText(Application.persistentDataPath + "/unlockedLevels.save");
        bool[] toSave = JsonUtility.FromJson<unlockedLevels>(jsonImport).unlocked;
        try
        {
            toSave[index] = true;
        }
        catch{ }

        unlockedLevels levelsToSave = new unlockedLevels(toSave);
        string jsonExport = JsonUtility.ToJson(levelsToSave);

        File.WriteAllText(Application.persistentDataPath + "/unlockedLevels.save", jsonExport);
    }

}

public class unlockedLevels
{
    public bool[] unlocked;

    public unlockedLevels(bool[] input)
    {
        unlocked = input;
    }
}
