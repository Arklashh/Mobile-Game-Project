using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
{
    public float dashSpeed = 10f;
    private Rigidbody rb;
    public float cooldown = 2f; // the amount of time in seconds before the player can dash again
    private float timer; // timer variable to keep track of the last dash

    public Button DashButton; // assign the button in the inspector

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = cooldown; // initialize the timer with the cooldown value
        DashButton = GameObject.Find("AbilityButton").GetComponent<Button>();

        if (DashButton != null)
        {
            DashButton.onClick.AddListener(PerformDash);
        }
    }

    private void Update()
    {
        if (timer < cooldown)
        {
            timer += Time.deltaTime; // increment the timer
        }
    }

    private void PerformDash()
    {
        if (timer >= cooldown)
        {
            Debug.Log("Dash");
            transform.Translate(transform.forward * dashSpeed * Time.deltaTime, Space.World);
            timer = 0; // reset the timer
        }
    }
}

