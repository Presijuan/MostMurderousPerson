using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Este script va unido al prefab de la bala
public class Bullet : MonoBehaviour
{
    // Variables
    public float damage = 10f;  // Daño por bala
    public float lifetime = 2f; // Tiempo max en la escena

    void Update()
    {
        Destroy(gameObject, lifetime); // Despues de un tiempo en escena destrullo la bala
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyAI enemy = other.GetComponent<EnemyAI>(); // Enemy debe tener el com
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Aplico daño al enemy
            Destroy(gameObject);      // Destruyo la bala
        }
    }
}
