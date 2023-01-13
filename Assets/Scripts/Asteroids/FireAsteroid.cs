using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAsteroid : AsteroidBase
{

    [SerializeField] private GameObject explosionParticle, underExplosionParticle, explosionRadius;
    
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
