using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnDistanceAhead = 50f;     // Distancia delante del jugador donde aparecen
    public float laneOffset = 4.5f;            // Separación entre carriles
    public Transform player;
    public float spawnStep = 25f;              // Cada cuántos metros generar obstáculos
    private float nextSpawnZ = 0f;             // Próxima posición Z para generar

    private void Start()
    {
        nextSpawnZ = player.position.z + spawnStep;
    }

    private void Update()
    {
        if (player.position.z + spawnDistanceAhead >= nextSpawnZ)
        {
            SpawnObstacles(nextSpawnZ);
            nextSpawnZ += spawnStep;
        }
    }

    private void SpawnObstacles(float spawnZ)
    {
        int numberOfObstacles = Random.Range(1, 3); // Máximo 2
        List<int> availableLanes = new List<int> { 0, 1, 2, 3 };

        for (int i = 0; i < numberOfObstacles && availableLanes.Count > 0; i++)
        {
            int laneIndex = Random.Range(0, availableLanes.Count);
            int lane = availableLanes[laneIndex];
            availableLanes.RemoveAt(laneIndex);

            float x = (lane - 1.5f) * laneOffset * 1.5f;

            GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            GameObject obstacle = Instantiate(prefab, new Vector3(x, 0, spawnZ), Quaternion.identity);

            Destroy(obstacle, 15f); // Se destruye después de 15 segundos
        }
    }
}
