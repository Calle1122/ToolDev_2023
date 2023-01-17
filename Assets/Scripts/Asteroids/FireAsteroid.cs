using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAsteroid : AsteroidBase
{

    [SerializeField] private GameObject explosionParticle, underExplosionParticle, explosionRadius;

    public bool hasTransformed = false;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        Vector2 dir = GameObject.Find("MidPoint").transform.position - transform.position;
        dir = dir.normalized;
        
        _rb.AddForce(dir * gameSettings.fireLaunchSpeed, ForceMode2D.Impulse);
    }
    
    private void Update()
    {
        transform.Rotate(Vector3.back, gameSettings.fireRotationSpeed * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, gameSettings.fireMaxSpeed);
    }
    
    protected override void OnCollideWithPlayer()
    {
        takeDamageEvent.Raise();
        
        DoExplosion();
        
        asteroidDestroyed.Raise();
        Destroy(gameObject);
    }

    public void DoExplosion()
    {
        GameObject newParticle = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(newParticle, 1f);
        GameObject underExplosion = Instantiate(underExplosionParticle, transform.position, Quaternion.identity);
        Destroy(underExplosion, 1f);

        GameObject explosionRad = Instantiate(explosionRadius, transform.position, Quaternion.identity);
        explosionRad.GetComponent<ExplosionRadius>().OnExplosion();
        Destroy(explosionRad, 1f);
    }

    public void KillFireAsteroid()
    {
        DoExplosion();
        
        asteroidDestroyed.Raise();
        Destroy(gameObject);
    }
}
