using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private GameObject laserPrefab;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireLaser();
        }
    }

    private void FireLaser()
    {
        Vector3 spawnPoint = GameObject.Find("LaserSpawn").transform.position;
        
        GameObject newLaser = Instantiate(laserPrefab, spawnPoint, Quaternion.identity);
        
        newLaser.GetComponent<Rigidbody2D>().AddForce(transform.up * gameSettings.laserAcceleration, ForceMode2D.Impulse);
        
        Destroy(newLaser, 3f);
    }
}
