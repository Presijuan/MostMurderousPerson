using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider; //(Entender que es)
    private Camera cameraP;

    private void Start()
    {
        cameraP = Camera.main;
    }

    public void UpdateHealth(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
    
    void Update()
    {
        transform.LookAt(cameraP.transform);
        transform.Rotate(0, 180, 0);
        
    }
}
