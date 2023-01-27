using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overdrive : MonoBehaviour
{
    public float OriginalSpeed; // Variable to store the original speed of the object.
    public float SpeedBoosted = 2.0f; // Variable to store the speed boost when the ability is used.
    public Button SpeedButton; // Variable to store the UI button that triggers the ability.

    private bool _isOnCooldown = false; // Variable to check if the ability is on cooldown.
    private float _cooldownTime = 5.0f; // Variable to store the duration of the cooldown.
    private float _cooldownStart; // Variable to store the time when the ability was last used.

    private void Start()
    {
        SpeedButton = GameObject.Find("AbilityButton").GetComponent<Button>(); // Finding the UI button by its name.

        if (SpeedButton != null)
        {
            SpeedButton.onClick.AddListener(SpeedBoost); // Adding a listener to the button to trigger the ability when clicked.
        }
    }

    private void Update()
    {
        if (_isOnCooldown) // Checking if the ability is on cooldown.
        {
            if (Time.time > _cooldownStart + _cooldownTime) // Checking if the cooldown time has passed.
            {
                _isOnCooldown = false; // Setting the cooldown status to false.
                SpeedButton.interactable = true; // Enabling the UI button.
                Debug.Log("Speed Boost Available"); // Logging that the ability is available.
            }
        }
    }

    private void SpeedBoost()
    {
        if (!_isOnCooldown) // Checking if the ability is not on cooldown.
        {
            OriginalSpeed *= SpeedBoosted; // Increasing the speed by the boost amount.
            Invoke("ResetSpeed", 10f); // Invoking the reset function after 10 seconds.

            _isOnCooldown = true; // Setting the cooldown status to true.
            _cooldownStart = Time.time; // Storing the time the ability was used.
            Debug.Log("Speed Boost on cooldown"); // Logging that the ability is on cooldown.
            SpeedButton.interactable = false; // Disabling the UI button.
        }
    }

    private void ResetSpeed()
    {
        OriginalSpeed /= SpeedBoosted; // Resetting the speed back to its original value.
    }
}

