using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalAsteroid : AsteroidBase
{

    [SerializeField] private GameObject dirtParticle;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        Vector2 dir = GameObject.Find("MidPoint").transform.position - transform.position;
        dir = dir.normalized;
        
        _rb.AddForce(dir * gameSettings.normalLaunchSpeed, ForceMode2D.Impulse);
    }
    
    private void Update()
    {
        transform.Rotate(Vector3.back, gameSettings.normalRotationSpeed * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, gameSettings.normalMaxSpeed);
    }
    
    protected override void OnCollideWithPlayer()
    {
        SpawnDirt();
        
        takeDamageEvent.Raise();
        Destroy(gameObject);
    }

    public void SpawnDirt()
    {
        GameObject newDirtPart = Instantiate(dirtParticle, transform.position, Quaternion.identity);
        Destroy(newDirtPart, 1f);
    }
}
