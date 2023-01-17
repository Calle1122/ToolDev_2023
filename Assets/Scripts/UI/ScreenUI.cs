using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScreenUI : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    
    [SerializeField] private TextMeshProUGUI healthTxt, scoreTxt, gameOverScoreTxt;

    [SerializeField] private GameObject gameOverContainer;

    private int _score = 0;
    
    private void Start()
    {
        UpdateHealthTxt();
        scoreTxt.text = "Score: " + _score;
    }

    public void UpdateHealthTxt()
    {
        healthTxt.text = "Health: " + settings.runtimeHealth;
    }

    public void AddScore()
    {
        _score += settings.pointsPerAsteroid;

        scoreTxt.text = "Score: " + _score;
    }

    public void OnGameOver()
    {
        healthTxt.enabled = false;
        scoreTxt.enabled = false;
        
        gameOverContainer.SetActive(true);
    }

    public void SetGameOverScore()
    {
        gameOverScoreTxt.text = "Final Score: " + _score;
    }
}
