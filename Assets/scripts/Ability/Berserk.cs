using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Berserk : MonoBehaviour
{
    public float OriginalSpeed;
    public float SpeedBoosted = 2.0f;
    public Button EnrageButton;

    private bool _isOnCooldown = false;
    private float _cooldownTime = 5.0f;
    private float _cooldownStart;

    private void Start()
    {
        EnrageButton = GameObject.Find("AbilityButton").GetComponent<Button>();

        if (EnrageButton != null)
        {
            EnrageButton.onClick.AddListener(SpeedBoost);
        }
    }

    private void Update()
    {
        if (_isOnCooldown)
        {
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
        if (!_isOnCooldown)
        {
            OriginalSpeed *= SpeedBoosted;
            Invoke("ResetSpeed", 10f);

            _isOnCooldown = true;
            _cooldownStart = Time.time;
            Debug.Log("Cannot go Berserk");
            EnrageButton.interactable = false;
        }
    }

    private void ResetSpeed()
    {
        OriginalSpeed /= SpeedBoosted;
    }
}
