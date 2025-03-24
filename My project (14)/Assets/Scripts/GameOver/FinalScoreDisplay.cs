using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText; // Texto del puntaje mas alto
    int finalScore;                                  // Puntaje final ultima ronda

    void Start()
    {
        finalScore = ScoreGameOver.instance.GetScore();         // Obtiene el puntaje
        GetComponent<TMP_Text>().text = finalScore + " Points"; // Muestra el puntaje final
        SetHighScore();                                         // Establece el puntaje mas alto
    }

    private void SetHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); // Obtiene el puntaje mas alto guardado

        if(finalScore > highScore)                          // Si el puntaje final es mayor al puntaje mas alto
        {
            PlayerPrefs.SetInt("HighScore", finalScore);    // Guarda el puntaje final como el nuevo puntaje mas alto
            highScore = finalScore;                         // Actualiza el puntaje mas alto
        }

        highScoreText.text = "High Score: " +  highScore;   // Muestra el puntaje mas alto
    }
}
