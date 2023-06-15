using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    public Button jumpButton;
    
    // Start is called before the first frame update
    void Start()
    {
        jumpButton = GetComponent<Button>();
        jumpButton.onClick.AddListener(QueueJump);
    }

    // This is the variable that will be used to check if the player can jump
    bool canJump = false;

    // This method will be called when the jump button is pressed
    void QueueJump()
    {
        // Set the canJump variable to true
        canJump = true; 
    }

    // This method will be called by the Character class to check if the player can jump
    public bool CanJump()
    {
        // If the player can jump, set the canJump variable to false and return true
        if (canJump)
        {
            canJump = false;
            return true;
        }
        return canJump;
    }
}
