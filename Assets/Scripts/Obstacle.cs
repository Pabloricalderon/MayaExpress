using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        BusHealth health = other.GetComponentInParent<BusHealth>();
        if (health != null)
        {
            
            health.TakeDamage();
            Destroy(gameObject); // Si quieres que desaparezca tras chocar
        }
    }
}

