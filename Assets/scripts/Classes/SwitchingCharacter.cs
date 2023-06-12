using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchingCharacter : MonoBehaviour
{
    // A reference to the current player object 
    public GameObject Player;

    // Prefab references to the different characters
    public GameObject HumanPrefab;
    public GameObject DwarfPrefab;
    public GameObject RobotPrefab;

    // References to the UI buttons for switching characters
    public Button HumanButton;
    public Button DwarfButton;
    public Button RobotButton;

    void Start()
    {
        // Assign the SwitchCharacter method to the onClick event for each button
        if (HumanButton != null)
            HumanButton.onClick.AddListener(() => SwitchCharacter(HumanPrefab));
        if (DwarfButton != null)
            DwarfButton.onClick.AddListener(() => SwitchCharacter(DwarfPrefab));
        if (RobotButton != null)
            RobotButton.onClick.AddListener(() => SwitchCharacter(RobotPrefab));
    }

    // Method for switching the character
    void SwitchCharacter(GameObject prefab)
    {
        // Store the current position and rotation
        Vector3 currentPosition = Player.transform.position;
        Quaternion currentRotation = Player.transform.rotation;

        // Destroy the current player object
        Destroy(Player);

        // Instantiate the new character prefab
        Player = Instantiate(prefab, currentPosition, currentRotation);

        // Get the Character component from the newly instantiated prefab
        Character character = Player.GetComponent<Character>();

        // Find the jump button in the new player object
        Button jumpButton = Player.GetComponentInChildren<Button>();
        
        // Attach the Jump method to the jump button's onClick event
        if (jumpButton != null)
            jumpButton.onClick.AddListener(character.Jump);
    }
}


