using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo
    public Transform[] spawnPoints; // Puntos de aparición de los enemigos
    public int enemiesPerRound = 3; // Número de enemigos a invocar por ronda
    private int currentRound = 1; // Contador de rondas
    private int activeEnemies = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerRound * currentRound; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            activeEnemies++;
            yield return new WaitForSeconds(0.5f); // Pequeña pausa entre spawns
        }
    }

    public void EnemyKilled()
    {
        activeEnemies--;
        if (activeEnemies == 0)
        {
            NextRound();
        }
    }

    void NextRound()
    {
        currentRound++;
        StartCoroutine(SpawnEnemies());
    }
}

