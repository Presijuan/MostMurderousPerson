using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private UIManager UIManager;
    private int health = 100;
    public int maxHealth = 100;

    void Start()
    {
        UIManager = FindObjectOfType<UIManager>(); // Busca y asigna UIManager en la escena
    }
    public void PlayerDamage(int damage)
    {
        UIManager.UpdatePlayerHealth(health, maxHealth);
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("Player Dead");
            health = 0;
        }
    }
}
