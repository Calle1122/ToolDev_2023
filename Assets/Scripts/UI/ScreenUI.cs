using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    [SerializeField] private ShipConfigs shipSettings;

    [SerializeField] private TextMeshProUGUI healthTxt, scoreTxt;

    private int _score = 0;
    
    private void Start()
    {
        UpdateHealthTxt();
        scoreTxt.text = "Score: " + _score;
    }

    public void UpdateHealthTxt()
    {
        healthTxt.text = "Health: " + shipSettings.health.RuntimeValue;
    }

    public void AddScore()
    {
        _score += 10;

        scoreTxt.text = "Score: " + _score;
    }
}
