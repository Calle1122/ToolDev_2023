using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<Rigidbody2D>().velocity =
                Vector2.Reflect(col.GetComponent<Rigidbody2D>().velocity, transform.up);
        }
    }
}
