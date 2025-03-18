using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float mouseSensitivity = 350f; // Sensibilidad variable del mouse
    public Transform playerBody;          // Identifico transfor del player
    private float xRotation = 0;          // Inicio rotacion en 0
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en pantalla
        //Cursor.lockState = CursorLockMode.None; (posible codigo para los menus)
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // Guarda movimiento de mouse en X
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; // Guarda movimiento de mouse en Y

        xRotation -=mouseY;                           // Lee movimiento en Y para hacer rotacion
        xRotation= Mathf.Clamp(xRotation, -90f, 90f); // Lee movimiento en X y lo limita

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Aplico rotacion a la camara
        playerBody.Rotate(Vector3.up*mouseX);                          // Aplico rotacion al player
    }
}
