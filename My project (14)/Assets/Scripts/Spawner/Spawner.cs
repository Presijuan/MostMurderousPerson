using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// Esta clase tiene la labor de manejar un sistema de creación de objetos en un tiempo específico, es decir, 
    /// cada cierto tiempo creará un objeto en el juego. El tiempo es previamente establecido y evaluado posteriormente 
    /// por un temporizador en la función built-in Update, la cual se ejecuta en cada frame del juego. 
    /// El objeto a crear es previamente definido y luego utilizado como referencia para generar copias de sí mismo.
    /// </summary>

    public class Spawner : MonoBehaviour
{
    //VARIABLES

    public GameObject enemyPrefab; //Seccion para colocar el Prefab 
    public float intervaloTiempo = 10f; //Cada cuanto quiero hacer el spawn
    private float temporizador = 8; //Cuenta el tiempo de juego
    public Transform pivot; //Referencia la zona de spawn
    public int maxObjetos = 3;


    private void Update()
    {
        // Aquí deberías implementar la lógica del temporizador.
        temporizador += Time.deltaTime; //Aumento el tiempo
        if (temporizador >= intervaloTiempo) // \
        {                                    //  \
            Spawn();                         //   } Si se cumple el tiempo invoca el Prefab y reinicia el tiempo
            temporizador = 0;                //  /
        }                                    // /
    }

    //FUNCIONES

    /// <summary>
    /// Esta función tiene la labor de crear objetos en algún punto del mundo, haciendo uso de un modelo de referencia y
    /// una posición en el plano cartesiano. Usa múltiples posiciones para crear objetos de manera más natural y arbitraria.
    /// </summary>
    
    public void Spawn()
    {
        if (pivot.childCount < maxObjetos)
        {
            if (enemyPrefab != null) // Siempre y cuando haya un objeto lo invoca
            {
                Vector3 posicion = pivot.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)); // Creo la zona de aparicion en un cudaro 1x1 cerca de la referencia
                Instantiate(enemyPrefab, posicion, Quaternion.identity, pivot); //Crea el objeto asignado en la posicion aleatorea y sin rotaciones
            }
            else
            {
                print("Falta definir un objeto a generar"); // Si no se ha asignado objeto manda una advertencia a la consola
            }
        }
    }
}