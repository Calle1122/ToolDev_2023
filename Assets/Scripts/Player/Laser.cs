using System;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private ShipConfigs shipSettings;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 v=_rb.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }

    private void FixedUpdate()
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, shipSettings.laserMaxSpeed.RuntimeValue);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.transform.tag)
        {
            case "Asteroid":
                //Normal Stuff
                
                //Destroy
                Destroy(col.gameObject);
                Destroy(gameObject);
                break;
            
            case "FireAsteroid":
                //Fire Stuff
                col.GetComponent<FireAsteroid>().DoExplosion();
                
                //Destroy
                Destroy(col.gameObject);
                Destroy(gameObject);
                break;
            
            case "IceAsteroid":
                //Ice stuff
                
                //Destroy
                Destroy(col.gameObject);
                Destroy(gameObject);
                break;
        }
    }
    
}
