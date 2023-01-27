using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveScript : MonoBehaviour
{

    public int CurrentLevel = 0;

    public string PlayerName = "";

    public string SavedString = "";

    private void Start()
    {
        LoadInt();
        LoadSave();
    }

    // Update is called once per frame
    public void SaveInt()
    {
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
        PlayerPrefs.SetString("PlayerName", PlayerName);
    }

    public void LoadInt()
    {
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
        PlayerName = PlayerPrefs.GetString("PlayerName");
    }

    public void SaveGame()
    {
        print("Saving Game");
        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
            print("Creating save path;" + Application.persistentDataPath);
        }
        if (!File.Exists(Application.dataPath + "/save.sav"))
        {
            using (StreamWriter sw = File.CreateText(Application.persistentDataPath + "/save.sav"));
            print("Creating file: " + Application.persistentDataPath + "/Save.sav");
        }

        var plainBytes = System.Text.Encoding.UTF8.GetBytes("Hello World");
        SavedString = System.Convert.ToBase64String(plainBytes);

        File.WriteAllText(Application.persistentDataPath + "/save.sav", SavedString);
    }

    void LoadSave()
    {

        var encodedBytes = System.Convert.FromBase64String(File.ReadAllText(Application.persistentDataPath + "/save.sav"));
        SavedString = System.Text.Encoding.UTF8.GetString(encodedBytes);

        print("Save Loaded" + SavedString);
    }
}
