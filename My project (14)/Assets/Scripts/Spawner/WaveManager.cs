using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private UIManager UIManager;

    public GameObject enemyPrefab;  // Prefab del enemigo
    public Transform[] spawnPoints; // Puntos de aparicion de los enemigos
    public int enemiesPerRound = 3; // Número de enemigos a invocar por ronda
    public int currentRound = 1;    // Contador de rondas
    private int activeEnemies = 0;  // LLevo un conteo de enemigos

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        UIManager = FindObjectOfType<UIManager>(); // Busca y asigna UIManager en la escena
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerRound * currentRound; i++)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)]; // Lugar aleatoreo de la lista spawnPoints
            Instantiate(enemyPrefab, spawnPoint.position,Quaternion.identity);       // Spawneo
            activeEnemies++;                                                         // +1 al contador de enemigos activos
            yield return new WaitForSeconds(0.5f);                                   // Pequeña pausa entre spawns
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
        UIManager.UpdateRound(currentRound);
    }
}