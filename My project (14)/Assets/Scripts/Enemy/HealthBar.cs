using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider; // Asigno un slider
    private Camera cameraP;

    private void Start()
    {
        cameraP = Camera.main; // Toma la camara principal como cameraP
    }

    public void UpdateHealth(float currentValue, float maxValue) // LLamado desde EnemyAI
    {
        slider.value = currentValue / maxValue; // Actualiza el slider
    }
    
    void Update()
    {
        transform.LookAt(cameraP.transform); // Mira a la misma direccion de la camara
        transform.Rotate(0, 180, 0);         // Lo gira para que barra y jugador se miren directamente
    }
}
