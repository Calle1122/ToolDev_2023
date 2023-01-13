using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Asteroid"))
        {
            Destroy(col.gameObject);
        }
    }
}
