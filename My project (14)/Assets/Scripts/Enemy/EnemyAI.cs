using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private WaveManager gameManager;
    [SerializeField] HealthBar healthBar;

    private Transform player;            // Referencia al jugador
    private NavMeshAgent agent;          // Componente de navegaci�n
    public float rangoDeAtaque = 2f;     // Rango de ataque
    public float attackCooldown = 1f;    // Tiempo entre ataques
    private float nextAttackTime = 0f;   // Ayudante de control de tiempo
    public float vida = 30f;            // Vida actual del enemigo
    public float vidaMax = 30f;            // Vida actual del enemigo

    void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();                          // Necesario para la AI
        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador en la escena
        healthBar.UpdateHealth(vida, vidaMax);
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

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
            Debug.Log("El enemigo ataca al jugador");
            nextAttackTime = Time.time + attackCooldown;
            // Aqu� puedes agregar da�o al jugador
        }
    }

    public void TakeDamage(float amount)
    {
        vida -= amount;
        healthBar.UpdateHealth(vida, vidaMax);
        if (vida <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemigo eliminado");
        Destroy(gameObject);
        FindObjectOfType<WaveManager>().EnemyKilled(); // Resta un enemigo
    }
}

