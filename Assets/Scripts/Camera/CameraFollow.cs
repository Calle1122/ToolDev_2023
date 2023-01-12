using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform camTarget;
    
    void Update()
    {
        transform.position = new Vector3(camTarget.position.x, camTarget.position.y, -10);
    }
}
