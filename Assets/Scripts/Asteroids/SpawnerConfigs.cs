using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnerConfigs : ScriptableObject
{
    public List<Vector3> spawnPoints = new List<Vector3>();
    public List<GameObject> possibleAsteroids = new List<GameObject>();

    public FloatVariable secondsBetweenSpawns;
}
