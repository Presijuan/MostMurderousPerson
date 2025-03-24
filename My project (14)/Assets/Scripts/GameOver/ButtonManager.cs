using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importa SceneManager

public class ButtonManager : MonoBehaviour
{
    public ScoreGameOver scoreGameOver;
    private void Start()
    {
        scoreGameOver = FindObjectOfType<ScoreGameOver>();
    }
    public void LoadScene()
    {
        scoreGameOver.score = 0;                  // Reinicia el puntaje
        SceneManager.LoadScene("Escenario");      // Cambia a la escena principal
        Cursor.lockState = CursorLockMode.Locked; // Bloqueo el cursor
        Cursor.visible = false;                   // No muestro el cursor
    }

    public void QuitGame()
    {
        Application.Quit(); // Cierra el juego
    }
}

