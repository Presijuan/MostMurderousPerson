using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Importa SceneManager

public class ButtonManagerCredits : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("Start"); // Cambia a la escena principal
    }
}
