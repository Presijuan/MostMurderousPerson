using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Es para cambiar de escena

public class PlayerHealth : MonoBehaviour
{
    private UIManager UIManager; // Tomo el codigo UIManager
    private int health = 100;    // Valor vida actual
    public int maxHealth = 100;  // Valor vida maxima

    void Start()
    {
        UIManager = FindObjectOfType<UIManager>(); // Busca y asigna UIManager en la escena
    }

    public void PlayerDamage(int damage)
    { 
        health -= damage;                                // Calculo del daño
        UIManager.UpdatePlayerHealth(health, maxHealth); // Actualiza UIManager
        if (health <= 0) NextEscene();                   // Escena GameOver
    }

    public void Heal(int heal)  // LLamado desde HealthPickup
    {
        if (health < 100)       // Verifico si se puede curar mas
        {
            health += heal;                                  // Calculo de curacion
            if (health > 100) health = 100;                  // Limite de vida
            UIManager.UpdatePlayerHealth(health, maxHealth); // Actualiza UIManager
        }   
    }

    public void NextEscene()
    {
        SceneManager.LoadScene("GameOver");       // Carga la escena
        Cursor.lockState = CursorLockMode.Locked; // Bloquea Cursor
        Cursor.visible = false;                   // Cursos Invisible
        Time.timeScale = 1;                       // Velocidad normal del juego (en caso de salir en la pausa)
    }
}
