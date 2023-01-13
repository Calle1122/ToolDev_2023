using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipConfigs : ScriptableObject
{

    public IntVariable health;
    
    public IntVariable damage;
    public FloatVariable laserSpeed;
    public FloatVariable laserMaxSpeed;
    
    public FloatVariable moveSpeed;
    public FloatVariable maxSpeed;
    public FloatVariable rotationSpeed;

}
