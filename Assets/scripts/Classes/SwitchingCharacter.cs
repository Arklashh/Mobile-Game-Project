using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingCharacter : MonoBehaviour
{
    //A reference to the current player object 
    public GameObject Player;
    //Prefab references to the different characters
    public GameObject HumanPrefab;
    public GameObject DwarfPrefab;
    public GameObject RobotPrefab;
    //References to the UI buttons for switching characters
    public Button HumanButton;
    public Button DwarfButton;
    public Button RobotButton;

    void Start()
    {
        //Assigns the SwitchCharacter method to the onClick event for each button
        if (HumanButton != null)
            HumanButton.onClick.AddListener(() => SwitchCharacter(HumanPrefab));
        if (DwarfButton != null)
            DwarfButton.onClick.AddListener(() => SwitchCharacter(DwarfPrefab));
        if (RobotButton != null)
            RobotButton.onClick.AddListener(() => SwitchCharacter(RobotPrefab));
    }

    //Method for switching the character
    void SwitchCharacter(GameObject prefab)
    {
        //Destroys the current player object
        Destroy(Player);
        //Instantiates the new character prefab
        Player = Instantiate(prefab);
    }
}


