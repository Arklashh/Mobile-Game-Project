using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Berserk : MonoBehaviour
{
    // Original speed of the character 
    public float OriginalSpeed;
    // Speed boost when the Berserk ability is activated
    public float SpeedBoosted = 2.0f;
    // Button for activating the Berserk ability
    public Button EnrageButton;

    // Flag to check if the ability is on cooldown
    private bool _isOnCooldown = false;
    // The cooldown time for the ability
    private float _cooldownTime = 5.0f;
    // The start time of the cooldown
    private float _cooldownStart;

    private void Start()
    {
        // Find the button for activating the Berserk ability
        EnrageButton = GameObject.Find("AbilityButton").GetComponent<Button>();

        // Add a listener to the button to activate the ability when clicked
        if (EnrageButton != null)
        {
            EnrageButton.onClick.AddListener(SpeedBoost);
        }
    }

    private void Update()
    {
        // Check if the ability is on cooldown
        if (_isOnCooldown)
        {
            // Check if the cooldown has ended
            if (Time.time > _cooldownStart + _cooldownTime)
            {
                _isOnCooldown = false;
                EnrageButton.interactable = true;
                Debug.Log("Berserk Available");
            }
        }
    }

    private void SpeedBoost()
    {
        // Check if the ability is not on cooldown
        if (!_isOnCooldown)
        {
            // Apply the speed boost
            OriginalSpeed *= SpeedBoosted;
            // Invoke the function to reset the speed after 10 seconds
            Invoke("ResetSpeed", 10f);

            // Set the ability on cooldown
            _isOnCooldown = true;
            _cooldownStart = Time.time;
            Debug.Log("Cannot go Berserk");
            EnrageButton.interactable = false;
        }
    }

    // Function to reset the speed to the original value
    private void ResetSpeed()
    {
        OriginalSpeed /= SpeedBoosted;
    }
}

