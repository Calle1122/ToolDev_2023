using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{

    [SerializeField] private ShipConfigs shipSettings;

    [SerializeField] private TextMeshProUGUI healthTxt;

    private void Start()
    {
        UpdateHealthTxt();
    }

    public void UpdateHealthTxt()
    {
        Debug.Log("Updating Health to " + shipSettings.health.RuntimeValue);
        healthTxt.text = "Health: " + shipSettings.health.RuntimeValue;
    }
}
