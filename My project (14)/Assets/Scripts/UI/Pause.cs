using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;  // Pantalla de pausa
    public bool isPaused = false; // El juego no inicia pausado

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) { // Si unde Esc o P Pausa
            if(isPaused==false)                         // Si no esta pausado
            {
                pauseMenu.SetActive(true);              // Pone pantalla de pausa
                isPaused = true;                        // Guarda valor de pausado
                Time.timeScale = 0;                     // Nada se mueve
                Cursor.lockState = CursorLockMode.None; // Libero el cursor
                Cursor.visible = true;                  // Muestro el cu
            }
            else                                        // Si esta pausado hago lo contrario
            {
                Resume();
            }
        }
    }

    public void Resume() // Codigo para continuar el juego (opuesto de la pausa)
    {   
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
