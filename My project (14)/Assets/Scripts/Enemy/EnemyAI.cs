using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

// Este script va unido al prefab del enemigo

public class EnemyAI : MonoBehaviour
{
    // LLamado de codigos
    private HealthBar healthBar;         // Tomo el codigo HelthBar
    private UIManager UIManager;         // Tomo el codigo UIManager
    private PlayerHealth playerHealth;   // Tomo el codigo PlayerHealth

    // Variables Principales
    public float rangoDeAtaque = 2f;     // Rango de ataque
    public float attackCooldown = 1f;    // Tiempo entre ataques
    public int damage = 10;              // Daño que hace el enemigo
    public float vidaMax = 30f;          // Vida maxima del enemigo

    private Transform player;            // Referencia al jugador
    private NavMeshAgent agent;          // Componente de navegacion
    private float nextAttackTime = 0f;   // Ayudante de control de tiempo
    private float vida = 30f;            // Vida actual del enemigo

    // Variables Para Otros Codigos
    public int puntosPorEnemigo = 100;   // Puntos que otorga al morir
    
    
    void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>(); // El prefab del enemigo debe tener un slider llamado "HealthBar"
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();                          // Necesario para la AI
        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador en la escena (Player debe tener tag "Player")
        healthBar.UpdateHealth(vida, vidaMax);                         // Envio a HealthBar los datos necesarios
        UIManager = FindObjectOfType<UIManager>();                     // Busca y asigna UIManager en la escena
        playerHealth = FindObjectOfType<PlayerHealth>();               // Busca y asigna PlayerHealth en la escena
    }

    void Update()
    {
        if (player != null) // Siempre y cuando haya un jugador se ejecuta lo siguiente
        {
            float distance = Vector3.Distance(transform.position, player.position); // Mido distancia entre Player y Enemy

            if (distance > rangoDeAtaque)
            {
                agent.SetDestination(player.position); // Perseguir al jugador
            }
            else
            {
                agent.ResetPath();                     // Detenerse al llegar al jugador
                Attack();                              // Ataca
            }
        }
    }

    void Attack()
    {

        if (Time.time >= nextAttackTime)
        {
            playerHealth.PlayerDamage(damage);           // Le quita vida al jugador
            nextAttackTime = Time.time + attackCooldown; // Ayudante de control de tiempo
        }
    }

    public void TakeDamage(float amount)
    {
        vida -= amount;                             // Le resto vida
        if (vida > 0)
        {
            healthBar.UpdateHealth(vida, vidaMax);  // Actualizo a HealthBar
        }
        else
        {
            Die();                                  // Muere
        }
    }

    void Die()
    {
        Destroy(gameObject);                           // Elimino el objeto Enemy
        UIManager.UpdateScore(puntosPorEnemigo);       // Envio puntaje por enemigo a UIManager
        FindObjectOfType<WaveManager>().EnemyKilled(); // Resta un enemigo en WaveManager
    }
}