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
        health -= damage;                                    // Calculo del daño
        UIManager.UpdatePlayerHealth(health, maxHealth);     // Actualiza UIManager
        if (health <= 0) SceneManager.LoadScene("GameOver"); // Escena GameOver
    }
}
