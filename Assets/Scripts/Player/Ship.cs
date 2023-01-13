using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private EventBase deathEvent;

    [SerializeField] private ShipConfigs shipSettings;

    private Rigidbody2D _rigidbody;
    
    public void TakeDamage()
    {
        shipSettings.health.RuntimeValue--;

        if (shipSettings.health.RuntimeValue <= 0)
        {
            deathEvent.Raise();
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
