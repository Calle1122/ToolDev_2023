using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAsteroid : AsteroidBase
{
    
    [SerializeField] private GameObject icePlosionParticle, underIceParticle, iceRadius;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        Vector2 dir = GameObject.Find("MidPoint").transform.position - transform.position;
        dir = dir.normalized;
        
        _rb.AddForce(dir * gameSettings.iceLaunchSpeed, ForceMode2D.Impulse);
    }
    
    private void Update()
    {
        transform.Rotate(Vector3.back, gameSettings.iceRotationSpeed * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, gameSettings.iceMaxSpeed);
    }
    
    protected override void OnCollideWithPlayer()
    {
        takeDamageEvent.Raise();

        DoIce();
        
        asteroidDestroyed.Raise();
        Destroy(gameObject);
    }

    public void DoIce()
    {
        GameObject newParticle = Instantiate(icePlosionParticle, transform.position, Quaternion.identity);
        Destroy(newParticle, 1f);
        GameObject underExplosion = Instantiate(underIceParticle, transform.position, Quaternion.identity);
        Destroy(underExplosion, 1f);

        GameObject explosionRad = Instantiate(iceRadius, transform.position, Quaternion.identity);
        explosionRad.GetComponent<IceRadius>().OnIce();
        Destroy(explosionRad, 1f);
    }
    
    public void KillIceAsteroid()
    {
        DoIce();
        
        asteroidDestroyed.Raise();
        Destroy(gameObject);
    }
    
}
