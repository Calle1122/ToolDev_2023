using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class IceRadius : MonoBehaviour
{
    [SerializeField] private GameObject normalAsteroid;

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.transform.tag)
        {
            case "Player":
                col.GetComponent<Rigidbody2D>().velocity *= 0.0001f;
                break;

            case "FireAsteroid":

                if (col.GetComponent<FireAsteroid>().hasTransformed == false)
                {
                    Vector2 currentVel = col.GetComponent<Rigidbody2D>().velocity;
                    Vector2 spawnPos = col.transform.position;
                
                    Destroy(col.gameObject);

                    GameObject newAsteroid = Instantiate(normalAsteroid, spawnPos, Quaternion.identity);
                    newAsteroid.GetComponent<Rigidbody2D>().velocity = currentVel;
                }

                col.GetComponent<FireAsteroid>().hasTransformed = true;
                
                break;
        }

        GetComponent<CircleCollider2D>().enabled = false;
    }

    public void OnIce()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
