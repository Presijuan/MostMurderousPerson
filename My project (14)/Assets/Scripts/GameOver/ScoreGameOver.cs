using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreGameOver : MonoBehaviour
{
    public static ScoreGameOver instance;
    public int score = 0; // Puntaje del jugador

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Mantiene este objeto en todas las escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe, destruye el duplicado
        }
    }
    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    //public void RestartGame()
    //{
    //    score = 0; // Reinicia el puntaje
    //    SceneManager.LoadScene("GameScene"); // Carga la escena del juego (ajusta el nombre de la escena)
    //}
}

