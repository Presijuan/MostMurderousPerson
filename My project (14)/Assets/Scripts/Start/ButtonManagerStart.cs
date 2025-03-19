using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importa SceneManager

public class ButtonManagerStart : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Spawner"); // Cambia a la escena principal
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("CreditsAsset"); // Cambia a las referencias
    }

    public void QuitGame()
    {
        Application.Quit(); // Cierra el juego
    }
}
