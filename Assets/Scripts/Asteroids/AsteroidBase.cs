using System;
using UnityEngine;

public abstract class AsteroidBase : MonoBehaviour
{

    [SerializeField] protected AsteroidConfigs asteroidSettings;
    
    [SerializeField] protected EventBase asteroidDestroyed;
    [SerializeField] protected EventBase takeDamageEvent;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        Vector2 dir = GameObject.Find("MidPoint").transform.position - transform.position;
        dir = dir.normalized;
        
        _rb.AddForce(dir * asteroidSettings.launchSpeed.RuntimeValue, ForceMode2D.Impulse);
    }
    
    private void Update()
    {
        transform.Rotate(Vector3.back, asteroidSettings.rotationSpeed.RuntimeValue * Time.deltaTime);
    }
    
    private void FixedUpdate()
    {
        _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, asteroidSettings.maxSpeed.RuntimeValue);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            OnCollideWithPlayer();
        }
    }

    protected virtual void OnCollideWithPlayer()
    {
        
    }

    private void OnDestroy()
    {
        asteroidDestroyed.Raise();
    }
}
