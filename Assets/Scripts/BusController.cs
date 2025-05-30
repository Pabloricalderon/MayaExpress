using UnityEngine;

public class BusController : MonoBehaviour
{
      public float laneOffset = 4.5f;     // Distancia entre carriles
    public float moveSpeed = 10f;       // Velocidad de desplazamiento lateral

    private int currentLane = 1;        // 0 a 3 (cuatro carriles)
    private int totalLanes = 4;
    private Vector3 targetLocalPosition;

    void Start()
    {
        UpdateTargetPosition();
    }

    void Update()
    {
        // Mover entre carriles (A / D o Flechas Izq / Der)
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            if (currentLane > 0)
            {
                currentLane--;
                UpdateTargetPosition();
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            if (currentLane < totalLanes - 1)
            {
                currentLane++;
                UpdateTargetPosition();
            }
        }

        // Movimiento suave hacia el carril objetivo
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetLocalPosition, Time.deltaTime * moveSpeed);
    }

    void UpdateTargetPosition()
    {
        float xPos = (currentLane - 1.5f) * laneOffset*1.5f; // Carriles centrados: -1.5, -0.5, 0.5, 1.5
        targetLocalPosition = new Vector3(xPos, transform.localPosition.y, transform.localPosition.z);
    }
}
