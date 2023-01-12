using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalAsteroid : AsteroidBase
{
    [SerializeField] private EventBase takeDamageEvent;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Vector2 dir = GameObject.Find("MidPoint").transform.position - transform.position;
        
        _rb.AddForce(dir, ForceMode2D.Impulse);
    }

    private void Update()
    {
        transform.RotateAround(Vector3.back, 1f*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, 5f);
    }

    protected override void OnCollideWithPlayer()
    {
        takeDamageEvent.Raise();
        Destroy(gameObject);
    }
}
