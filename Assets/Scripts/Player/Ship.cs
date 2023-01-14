using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private EventBase deathEvent;

    [SerializeField] private ShipConfigs shipSettings;

    [SerializeField] private GameObject bigFlame, lFlame, rFlame;

    private Rigidbody2D _rigidbody;
    
    public void TakeDamage()
    {
        shipSettings.health.RuntimeValue--;

        if (shipSettings.health.RuntimeValue <= 0)
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

        _rigidbody.velocity = Vector2.ClampMagnitude(_rigidbody.velocity, shipSettings.maxSpeed.RuntimeValue);

    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        ResetShipRuntimeVariables();
    }

    public void ResetShipRuntimeVariables()
    {
        shipSettings.damage.RuntimeValue = shipSettings.damage.initialValue;
        shipSettings.health.RuntimeValue = shipSettings.health.initialValue;
        shipSettings.laserSpeed.RuntimeValue = shipSettings.laserSpeed.initialValue;
        shipSettings.maxSpeed.RuntimeValue = shipSettings.maxSpeed.initialValue;
        shipSettings.moveSpeed.RuntimeValue = shipSettings.moveSpeed.initialValue;
        shipSettings.rotationSpeed.RuntimeValue = shipSettings.rotationSpeed.initialValue;
        shipSettings.laserMaxSpeed.RuntimeValue = shipSettings.laserMaxSpeed.initialValue;
    }
    
    public void Throttle()
    {
        _rigidbody.AddForce(transform.up * shipSettings.moveSpeed.RuntimeValue, ForceMode2D.Force);
    }

    public void SteerLeft()
    {
        _rigidbody.AddTorque(shipSettings.rotationSpeed.RuntimeValue, ForceMode2D.Force);
    }

    public void SteerRight()
    {
        _rigidbody.AddTorque(-shipSettings.rotationSpeed.RuntimeValue, ForceMode2D.Force);
    }
}
