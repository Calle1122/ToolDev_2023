using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalAsteroid : AsteroidBase
{
    protected override void OnCollideWithPlayer()
    {
        takeDamageEvent.Raise();
        Destroy(gameObject);
    }
}
