using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 20; // Cantidad de vida que recupera

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifico que lo recoge  el jugador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount); // Cura al jugador
                Destroy(gameObject);           // Destruye el objeto de curación
            }
        }
    }
}

