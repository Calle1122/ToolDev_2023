using System;
using UnityEngine;

public abstract class AsteroidBase : MonoBehaviour
{
    [SerializeField] protected GameSettings gameSettings;
    
    [SerializeField] protected EventBase asteroidDestroyed;
    [SerializeField] protected EventBase takeDamageEvent;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            OnCollideWithPlayer();
        }
    }

    protected virtual void OnCollideWithPlayer()
    {
        
    }

    private void OnDestroy()
    {
        asteroidDestroyed.Raise();
    }
}
