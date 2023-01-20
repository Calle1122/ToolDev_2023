using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private SpawnerConfigs spawnSettings;

    [SerializeField] private GameSettings gameSettings;

    private float _spawnTimer = 0f;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= gameSettings.secondsBetweenSpawns)
        {
            _spawnTimer = 0f;

            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        //if no points are selected:
        if (gameSettings.topSpawn == false && gameSettings.bottomSpawn == false && gameSettings.leftSpawn == false && gameSettings.rightSpawn == false)
        {
            int posPicker = Random.Range(0, spawnSettings.spawnPoints.Count);
            Vector3 spawnPoint = spawnSettings.spawnPoints[posPicker];

            int asteroidPicker = Random.Range(0, spawnSettings.possibleAsteroids.Count);
            GameObject asteroidToSpawn = spawnSettings.possibleAsteroids[asteroidPicker];

            Instantiate(asteroidToSpawn, spawnPoint, Quaternion.identity);
        }

        else
        {
            List<Vector3> possibleSpawns = new List<Vector3>();

            if (gameSettings.topSpawn)
            {
                foreach (Vector3 pos in spawnSettings.topPoints)
                {
                    possibleSpawns.Add(pos);
                }
            }
            if (gameSettings.bottomSpawn)
            {
                foreach (Vector3 pos in spawnSettings.bottomPoints)
                {
                    possibleSpawns.Add(pos);
                }
            }
            if (gameSettings.leftSpawn)
            {
                foreach (Vector3 pos in spawnSettings.leftPoints)
                {
                    possibleSpawns.Add(pos);
                }
            }
            if (gameSettings.rightSpawn)
            {
                foreach (Vector3 pos in spawnSettings.rightPoints)
                {
                    possibleSpawns.Add(pos);
                }
            }
            
            int posPicker = Random.Range(0, possibleSpawns.Count);
            Vector3 spawnPoint = possibleSpawns[posPicker];

            int asteroidPicker = Random.Range(0, spawnSettings.possibleAsteroids.Count);
            GameObject asteroidToSpawn = spawnSettings.possibleAsteroids[asteroidPicker];

            Instantiate(asteroidToSpawn, spawnPoint, Quaternion.identity);
            
        }
    }
    
}
