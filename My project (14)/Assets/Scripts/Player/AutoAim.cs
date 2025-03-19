using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public Camera playerCamera;      // Cámara del jugador
    public Transform gun;            // Referencia al arma
    public LayerMask aimMask;        // Capas que se pueden detectar (enemigos, objetos, etc.)
    public float maxDistance = 300f; // Distancia máxima del raycast

    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, aimMask)) // Si el raycast golpea algo, apunta el arma hacia ese punto
        {
            gun.LookAt(hit.point);
        }
        else // Si no golpea nada, apunta en la dirección de la cámara
        {
            gun.rotation = Quaternion.LookRotation(playerCamera.transform.forward);
        }
    }
}

