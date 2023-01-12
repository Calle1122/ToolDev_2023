using UnityEngine;

public abstract class AsteroidBase : MonoBehaviour
{
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
}
