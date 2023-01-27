using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    // Speed of the dash
    public float dashSpeed = 10f;
    // Rigidbody component of the object
    private Rigidbody rb;
    // Cooldown time for the dash
    public float cooldown = 2f;
    // Timer for the cooldown
    private float timer;

    // Dash button
    public Button DashButton;

    private void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
        // Set the timer to the cooldown
        timer = cooldown;
        // Find the Dash button
        DashButton = GameObject.Find("AbilityButton").GetComponent<Button>();

        // Add a listener to the button to activate the dash when clicked
        if (DashButton != null)
        {
            DashButton.onClick.AddListener(PerformDash);
        }
    }

    private void Update()
    {
        // Check if the timer is less than the cooldown
        if (timer < cooldown)
        {
            // Increase the timer
            timer += Time.deltaTime;
        }
    }

    // Function to perform the dash
    private void PerformDash()
    {
        // Check if the cooldown is finished
        if (timer >= cooldown)
        {
            Debug.Log("Dash");
            // Move the object forward
            transform.Translate(transform.forward * dashSpeed * Time.deltaTime, Space.World);
            // Reset the timer
            timer = 0;
        }
    }
}


