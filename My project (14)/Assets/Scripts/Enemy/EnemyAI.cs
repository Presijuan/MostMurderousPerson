using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private WaveManager gameManager;

    private Transform player;            // Referencia al jugador
    private NavMeshAgent agent;          // Componente de navegación
    public float rangoDeAtaque = 2f;     // Rango de ataque
    public float attackCooldown = 1f;    // Tiempo entre ataques
    private float nextAttackTime = 0f;   // Ayudante de control de tiempo
    public float vida = 100f;            // Vida del enemigo

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();                          // Necesario para la AI
        player = GameObject.FindGameObjectWithTag("Player").transform; // Busca al jugador en la escena
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
            // Aquí puedes agregar daño al jugador
        }
    }

    public void TakeDamage(float amount)
    {
        vida -= amount;
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

