using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private UIManager UIManager;    // Tomo el codigo UIManager

    public GameObject[] enemyPrefab; // Prefab del enemigo(s)
    public Transform[] spawnPoints;  // Puntos de aparicion de los enemigos
    public int enemiesPerRound = 3;  // Número de enemigos a invocar por ronda
    public int currentRound = 1;     // Contador de rondas
    private int activeEnemies = 0;   // LLevo un conteo de enemigos

    void Start()
    {
        StartCoroutine(SpawnEnemies());            // Es corrutina para hacer pausas dentro del codigo
        UIManager = FindObjectOfType<UIManager>(); // Busca y asigna UIManager en la escena
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerRound * currentRound; i++)                            // Segun la ronda y enemgos por ronda hago spawn
        {
            int randomEnemy = Random.Range(0, enemyPrefab.Length);                          // Tomo aleatoreamente un modelo
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];        // Lugar aleatoreo de la lista spawnPoints
            Instantiate(enemyPrefab[randomEnemy], spawnPoint.position,Quaternion.identity); // Spawneo
            activeEnemies++;                                                                // +1 al contador de enemigos activos
            yield return new WaitForSeconds(0.5f);                                          // Pequeña pausa entre spawns
        }
    }

    public void EnemyKilled()
    {
        activeEnemies--;        // -1 al contador de enemigos activos
        if (activeEnemies == 0)
        {
            NextRound();        // Si ya no quedan enemigos paso a la proxima ronda
        }
    }

    void NextRound()
    {
        currentRound++;                      // +1 al contador de rondas
        StartCoroutine(SpawnEnemies());      // Al pasar de ronda genero nuevos enemigos
        UIManager.UpdateRound(currentRound); // Actuializo la ronda en UI
    }
}