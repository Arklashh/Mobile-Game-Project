using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveScript : MonoBehaviour
{
    // Public integer to store the current level.
    public int CurrentLevel = 0;

    // Public string to store the saved string.
    public string SavedString = "";

    // Start function is called when the script is first run.
    private void Start()
    {
        // Load the integer.
        LoadInt();
        // Load the saved string.
        LoadSave();
    }

    // SaveInt method saves the current level as an integer to PlayerPrefs.
    public void SaveInt()
    {
        PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
    }

    // LoadInt method loads the saved integer from PlayerPrefs.
    public void LoadInt()
    {
        CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
    }

    // SaveGame method saves the saved string to a file.
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

    // LoadSave method loads the saved string from the file.
    void LoadSave()
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
}

