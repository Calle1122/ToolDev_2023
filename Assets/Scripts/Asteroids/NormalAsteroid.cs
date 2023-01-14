using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalAsteroid : AsteroidBase
{

    [SerializeField] private GameObject dirtParticle;
    
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
