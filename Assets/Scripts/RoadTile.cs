
using UnityEngine;

public class RoadTile : MonoBehaviour
{
    public static float tileLength = 70f; // Largo del tramo de carretera
    public static Transform player; // La cámara o el jugador
    public static float triggerDistance = 40f; // Qué tan cerca debe estar para mover el tile

    private void Update()
    {
        if (player == null) return;

        // Si este tramo está detrás del jugador
        if (player.position.z - transform.position.z > triggerDistance)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        transform.position += new Vector3(0, 0, tileLength * 3); // Mueve 3 tramos adelante
    }
}


