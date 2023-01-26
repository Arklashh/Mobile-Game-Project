using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overdrive : MonoBehaviour
{
    public float OriginalSpeed;
    public float SpeedBoosted = 2.0f;
    public Button SpeedButton;

    private bool _isOnCooldown = false;
    private float _cooldownTime = 5.0f;
    private float _cooldownStart;

    private void Start()
    {
        SpeedButton = GameObject.Find("AbilityButton").GetComponent<Button>();

        if (SpeedButton != null)
        {
            SpeedButton.onClick.AddListener(SpeedBoost);
        }
    }

    private void Update()
    {
        if (_isOnCooldown)
        {
            if (Time.time > _cooldownStart + _cooldownTime)
            {
                _isOnCooldown = false;
                SpeedButton.interactable = true;
                Debug.Log("Speed Boost Available");
            }
        }
    }

    private void SpeedBoost()
    {
        if (!_isOnCooldown)
        {
            OriginalSpeed *= SpeedBoosted;
            Invoke("ResetSpeed", 10f);

            _isOnCooldown = true;
            _cooldownStart = Time.time;
            Debug.Log("Speed Boost on cooldown");
            SpeedButton.interactable = false;
        }
    }

    private void ResetSpeed()
    {
        OriginalSpeed /= SpeedBoosted;
    }
}
