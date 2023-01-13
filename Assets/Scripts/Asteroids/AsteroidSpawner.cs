using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private SpawnerConfigs spawnSettings;

    private float _spawnTimer = 0f;

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= spawnSettings.secondsBetweenSpawns.RuntimeValue)
        {
            _spawnTimer = 0f;

            SpawnAsteroid();
        }
    }

    private void SpawnAsteroid()
    {
        int posPicker = Random.Range(0, spawnSettings.spawnPoints.Count);
        Vector3 spawnPoint = spawnSettings.spawnPoints[posPicker];

        int asteroidPicker = Random.Range(0, spawnSettings.possibleAsteroids.Count);
        GameObject asteroidToSpawn = spawnSettings.possibleAsteroids[asteroidPicker];

        Instantiate(asteroidToSpawn, spawnPoint, Quaternion.identity);
    }
    
}
