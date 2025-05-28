using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BusHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;
    private float distanceTraveled = 0f;
    private Vector3 startPosition;
    public TextMeshProUGUI gameOverText;
    
    public TextMeshProUGUI livesText;

    public GameObject gameOverUI;

    void Start()
    {
        gameOverUI.GetComponent<GameOverUI>();
        currentLives = maxLives;
        startPosition = transform.position;
        Time.timeScale = 1f; // Asegura que el juego esté corriendo
        gameOverText.gameObject.SetActive(false);
        livesText.gameObject.SetActive(true);
        livesText.text = "Vidas: " + currentLives;

    }

    void Update()
    {
        distanceTraveled = transform.position.z - startPosition.z;
    }

    public void TakeDamage()
    {
        if (currentLives > 0)
        {
            currentLives--;


            livesText.text = "Vidas: " + currentLives;
            if (currentLives <= 0)
            {
                GameOver();
            }
        }
       
    }

    void GameOver()
    {
        Time.timeScale = 0f; // Detiene el juego
        if (gameOverUI != null)
        {

            gameOverUI.SetActive(true);
            gameOverText.text = "Juego Terminado. Distancia: " + (int)distanceTraveled + "m";
            gameOverText.gameObject.SetActive(true);
            
        }
       
    }
}

