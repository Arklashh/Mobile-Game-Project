using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveScript : MonoBehaviour
{
    public int CurrentLevel = 0;
    public string SavedString = "";

    public void Start()
    {
        LoadSave();
        LoadInt();
    }

    public void SaveGame()
    {
        print("Saving Game");
        // Check if the persistent data path exists.
        if (!Directory.Exists(Application.persistentDataPath))
        {
            // If not, create the directory.
            Directory.CreateDirectory(Application.persistentDataPath);
            print("Creating save path;" + Application.persistentDataPath);
        }
        // Try to save the file.
        try
        {
            // Check if the save file exists.
            if (!File.Exists(Application.dataPath + "/save.sav"))
            {
                // If not, create the file.
                using (StreamWriter sw = File.CreateText(Application.persistentDataPath + "/save.sav"))
                    print("Creating file: " + Application.persistentDataPath + "/Save.sav");
            }
            // Convert the string "Hello World" to bytes and then to a base64 string.
            var plainBytes = System.Text.Encoding.UTF8.GetBytes("Hello World");
            SavedString = Convert.ToBase64String(plainBytes);
            // Write the base64 string to the save file.
            File.WriteAllText(Application.persistentDataPath + "/save.sav", SavedString);
        }
        // Catch any exceptions and print an error message.
        catch (Exception e)
        {
            print("Error saving file: " + e.Message);
        }
    }
    public void LoadSave()
    {
        // Try to load the saved string.
        try
        {
            // Convert the base64 string in the save file to a regular string.
            var encodedBytes = System.Convert.FromBase64String(File.ReadAllText(Application.persistentDataPath + "/save.sav"));
            SavedString = System.Text.Encoding.UTF8.GetString(encodedBytes);
            // Print a message indicating that the save was loaded.
            print("Save Loaded" + SavedString);
        }
        // Catch a FileNotFoundException and print an error message.
        catch (FileNotFoundException e)
        {
            print("Save file not found" + e.Message);
        }
    }

    void LoadInt()
    {
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }

    void SaveInt()
    {
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
    }

}

