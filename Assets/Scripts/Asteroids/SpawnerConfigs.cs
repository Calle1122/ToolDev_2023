using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnerConfigs : ScriptableObject
{
    public List<Vector3> spawnPoints = new List<Vector3>();
    public List<Vector3> topPoints = new List<Vector3>();
    public List<Vector3> bottomPoints = new List<Vector3>();
    public List<Vector3> leftPoints = new List<Vector3>();
    public List<Vector3> rightPoints = new List<Vector3>();

    public List<GameObject> possibleAsteroids = new List<GameObject>();
}
