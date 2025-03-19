using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    void Start()
    {
        int finalScore = ScoreGameOver.instance.GetScore(); // Obtiene el puntaje
        GetComponent<TMP_Text>().text = finalScore + " Puntos";
    }
}
