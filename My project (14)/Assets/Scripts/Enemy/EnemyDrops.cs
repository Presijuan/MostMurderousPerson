using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrops : MonoBehaviour
{
    public GameObject healthPickupPrefab; // Prefab del objeto de curación
    public float      dropChance = 0.15f; // Probabilidad de soltar item

    public void DropHealthPickup()
    {
        float randomValue = Random.value; // Genera un número entre 0 y 1
        if (randomValue < dropChance)     // Si es menor que la probabilidad
        {
            Vector3 spawnPosition = transform.position + Vector3.up * 1f;        // Defino altura
            Instantiate(healthPickupPrefab, spawnPosition, Quaternion.identity); // Invoco curacion
        }
    }
}
