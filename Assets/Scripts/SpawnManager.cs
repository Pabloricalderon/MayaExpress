using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnDistanceAhead = 50f;
    public float laneOffset = 4.5f;
    public Transform player;
    public float spawnInterval = 70f;  // Menos frecuente
    private float lastSpawnZ;

    void Start()
    {
        lastSpawnZ = player.position.z;
    }

    void Update()
    {
        if (player.position.z - lastSpawnZ >= spawnInterval)
        {
            SpawnObstacles();
            lastSpawnZ = player.position.z;
        }
    }

    void SpawnObstacles()
    {
        int numberOfObstacles = Random.Range(1, 3);  // Máximo 2 por tanda
        List<int> availableLanes = new List<int> { 0, 1, 2, 3 };

        for (int i = 0; i < numberOfObstacles && availableLanes.Count > 0; i++)
        {
            int laneIndex = Random.Range(0, availableLanes.Count);
            int lane = availableLanes[laneIndex];
            availableLanes.RemoveAt(laneIndex);  // No repetir carril

            float x = (lane - 1.5f) * laneOffset * 1.5f;
            float z = player.position.z + spawnDistanceAhead;

            GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Instantiate(prefab, new Vector3(x, 0, z), Quaternion.identity);
        }
    }
}


