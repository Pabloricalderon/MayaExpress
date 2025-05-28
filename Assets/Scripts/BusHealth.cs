using UnityEngine;
using UnityEngine.SceneManagement;

public class BusHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    private float distanceTraveled = 0f;
    private Vector3 startPosition;

    public GameObject gameOverUI;

    void Start()
    {
        currentLives = maxLives;
        startPosition = transform.position;
        Time.timeScale = 1f; // Asegura que el juego esté corriendo
    }

    void Update()
    {
        distanceTraveled = transform.position.z - startPosition.z;
    }

    public void TakeDamage()
    {
        currentLives--;
        Debug.Log("¡Colisión! Vidas restantes: " + currentLives);

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f; // Detiene el juego
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            gameOverUI.GetComponent<GameOverUI>().ShowStats((int)distanceTraveled);
        }
        else
        {
            Debug.Log("Game Over. Distancia: " + (int)distanceTraveled + " m");
        }
    }
}

