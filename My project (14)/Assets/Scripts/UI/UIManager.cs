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
    private int round = 1;   // Contador de rondas en este codigo (es necesario ya que el otro contador de rondas no lo puedo llamar en LateUpdate)
    private int points;

    public void UpdateRound(int roundcount)
    {
        round = roundcount; // Tomo el conteo desde el otro codigo
    }

    public void UpdateScore(int pointscount)
    {
        points += pointscount; // LLevo un puntaje
    }

    void LateUpdate() // Imprimo lo necesario a la pantalla
    {
        wave.text = "Wave " + round;
        score.text = points + " puntos";

    }

    public void UpdatePlayerHealth(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
        health.text = currentValue.ToString();
    }
}
