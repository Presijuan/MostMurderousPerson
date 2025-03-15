using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

// Script unido al player
// Debo añadir sistema de conteo de balas para recargar

public class PlayerShooting : MonoBehaviour
{
    //Variables
    public GameObject bulletPrefab;  // Referencia de la bala
    public Transform firePoint;      // Lugar del que sale la bala
    public float bulletSpeed = 10f;  // Velocidad bala

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1 es ClickIzquierdo
        {
            Shoot();                      // Disparar
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); // Creo la bala y la ubico con una rotación
        Rigidbody rb = bullet.GetComponent<Rigidbody>();                                       // El prefab de la bala debe tener rb
        rb.velocity = firePoint.forward * bulletSpeed;                                         // Le doy una velocidad para que se dispare
    }
}

