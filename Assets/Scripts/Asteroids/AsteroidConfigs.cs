using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AsteroidConfigs : ScriptableObject
{
    public IntVariable health;

    public FloatVariable launchSpeed;
    public FloatVariable maxSpeed;
    public FloatVariable rotationSpeed;
}
