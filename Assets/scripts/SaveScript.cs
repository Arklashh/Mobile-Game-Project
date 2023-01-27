using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveScript : MonoBehaviour
{

    // Public variables to be saved
    public int CurrentLevel = 0;
    public string PlayerName = "";
    public string SavedString = "";

    private void Start()
    {
        // Load saved values when the script starts
        LoadInt();
        LoadSave();
    }

    // Update is called once per frame
    public void SaveInt()
    {
        // Save the int value of CurrentLevel and the string value of PlayerName to PlayerPrefs
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
        PlayerPrefs.SetString("PlayerName", PlayerName);
    }

    public void LoadInt()
    {
        // Load the int value of CurrentLevel and the string value of PlayerName from PlayerPrefs
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
        PlayerName = PlayerPrefs.GetString("PlayerName");
    }

    public void SaveGame()
    {
        print("Saving Game");
        // Check if the save directory exists, if not, create it
        if (!Directory.Exists(Application.persistentDataPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath);
            print("Creating save path;" + Application.persistentDataPath);
        }
        // Check if the save file exists, if not, create it
        if (!File.Exists(Application.dataPath + "/save.sav"))
        {
            using (StreamWriter sw = File.CreateText(Application.persistentDataPath + "/save.sav")) ;
            print("Creating file: " + Application.persistentDataPath + "/Save.sav");
        }

        // Encode the string value of SavedString to a byte array
        var plainBytes = System.Text.Encoding.UTF8.GetBytes("Hello World");
        // Convert the byte array to a base64 string
        SavedString = System.Convert.ToBase64String(plainBytes);

        // Write the base64 string to the save file
        File.WriteAllText(Application.persistentDataPath + "/save.sav", SavedString);
    }

    void LoadSave()
    {
        // Read the contents of the save file as a base64 string
        var encodedBytes = System.Convert.FromBase64String(File.ReadAllText(Application.persistentDataPath + "/save.sav"));
        // Decode the base64 string to a string
        SavedString = System.Text.Encoding.UTF8.GetString(encodedBytes);

        print("Save Loaded" + SavedString);
    }
}

