using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables
    public float moveSpeed = 5f;            // Velocidad de movimiento
    public float mouseSensitivity = 2f;     // Sensivilidad de la camara
    public Transform cameraTransform;       // Ubicación de la camara

    private CharacterController controller; // El prefab necesita el componente CharacterController
    private Vector3 moveDirection;          // Ayuda al movimiento
    private float gravity = 9.8f;           // Valor de gravedad (Puede ser publico)
    private float verticalVelocity;         // Ayuda a la gravedad
    private float xRotation = 0f;           // Valor para movimiento camara

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor en pantalla
    }

    void Update()
    {
        MovePlayer();   // Mueve cuerpo
        RotateCamera(); // Mueve camara
    }

    void MovePlayer()
    {
        // Defino el vector de dirección
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        moveDirection = move * moveSpeed;

        // Aplicar gravedad
        if (controller.isGrounded)
        {
            verticalVelocity = -2f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        // Aplico el movimiento segun la dirección
        moveDirection.y = verticalVelocity;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void RotateCamera()
    {
        // Encuentro posicion mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotar el cuerpo del jugador en el eje Y
        transform.Rotate(Vector3.up * mouseX);

        // Rotar la cámara en el eje X (mirar arriba y abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

