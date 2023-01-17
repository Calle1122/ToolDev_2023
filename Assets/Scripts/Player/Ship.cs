using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private EventBase deathEvent;

    [SerializeField] private GameSettings gameSettings;

    [SerializeField] private GameObject bigFlame, lFlame, rFlame;

    private Rigidbody2D _rigidbody;
    
    public void TakeDamage()
    {
        gameSettings.runtimeHealth--;

        if (gameSettings.runtimeHealth <= 0)
        {
            deathEvent.Raise();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            bigFlame.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            bigFlame.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rFlame.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rFlame.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lFlame.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            lFlame.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Throttle();
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SteerLeft();
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            SteerRight();
        }

        _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, gameSettings.shipMaxSpeed);

    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        ResetShipRuntimeVariables();
    }

    public void ResetShipRuntimeVariables()
    {
        gameSettings.runtimeHealth = gameSettings.shipHealth;
    }
    
    public void Throttle()
    {
        _rigidbody.AddForce(transform.up * gameSettings.shipAcceleration, ForceMode2D.Force);
    }

    public void SteerLeft()
    {
        _rigidbody.AddTorque(gameSettings.shipRotation, ForceMode2D.Force);
    }

    public void SteerRight()
    {
        _rigidbody.AddTorque(-gameSettings.shipRotation, ForceMode2D.Force);
    }
}
