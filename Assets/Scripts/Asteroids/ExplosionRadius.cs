using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{

    [SerializeField] private EventBase takeDamageEvent;
    
    public void OnExplosion()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.transform.tag)
        {
            case "Player":
                takeDamageEvent.Raise();
                break;
            
            case "Asteroid":

                col.GetComponent<NormalAsteroid>().SpawnDirt();
                Destroy(col.gameObject);

                break;
            
            case "FireAsteroid":
                col.GetComponent<FireAsteroid>().KillFireAsteroid();
                break;
            
            case "IceAsteroid":
                col.GetComponent<IceAsteroid>().KillIceAsteroid();
                break;
            
            default:
                Destroy(col.gameObject);
                break;
        }
        
        GetComponent<CircleCollider2D>().enabled = false;
    }
}
