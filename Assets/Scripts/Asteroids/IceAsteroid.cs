using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAsteroid : AsteroidBase
{
    
    [SerializeField] private GameObject icePlosionParticle, underIceParticle, iceRadius;
    
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
