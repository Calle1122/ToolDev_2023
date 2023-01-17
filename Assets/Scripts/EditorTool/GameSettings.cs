using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class GameSettings : ScriptableObject
{
    //Ship
    public float laserMaxSpeed;
    public float laserAcceleration;
    public float shipMaxSpeed;
    public float shipAcceleration;
    public float shipRotation;
    public int shipHealth;
    public Color hullColor;
    public Color laserColor;


    //Asteroids
    //Normal
    public float normalLaunchSpeed;
    public float normalMaxSpeed;
    public float normalRotationSpeed;
    //Fire
    public float fireLaunchSpeed;
    public float fireMaxSpeed;
    public float fireRotationSpeed;
    //Ice
    public float iceLaunchSpeed;
    public float iceMaxSpeed;
    public float iceRotationSpeed;


    //Game Settings
    public float secondsBetweenSpawns;
    public int pointsPerAsteroid;
    public float cameraShakeModifier;
    
    
    //Runtime Variables
    public int runtimeHealth;
}
