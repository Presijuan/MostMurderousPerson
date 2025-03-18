using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider slider; 
    public TMP_Text wave;    // Asigno Text Mesh de oleadas
    public TMP_Text score;   // Asigno Text Mesh de puntos
    public TMP_Text bullets; // Asigno Text Mesh de balas
    public TMP_Text health;  // Asigno Text Mesh de vida
    private int round = 1;   // Contador de rondas en este codigo
    private int points;

    public void UpdateRound(int roundcount) // Es llamado desde WaveManager
    {
        round = roundcount;                 // Tomo el conteo desde el otro codigo
    }

    public void UpdateScore(int pointscount) // Es llamado desde EnemyAI
    {
        points += pointscount;               // Actualizo el puntaje actual
    }

    void LateUpdate()                    // Imprimo lo necesario a la pantalla
    {
        wave.text = "Wave " + round;     // Creo string para wave
        score.text = points + " puntos"; // Creo string para score
    }

    public void UpdatePlayerHealth(float currentValue, float maxValue) // Es llamado desde PlayerHealth
    {
        slider.value = currentValue / maxValue;                        // Hago proporcion para slider
        health.text = currentValue.ToString();                         // Creo string para health
    }
}