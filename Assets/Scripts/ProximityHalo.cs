using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityHalo : MonoBehaviour
{
    public GameObject haloObject;        // Objeto que representa el halo visual
    public string targetTag = "Player";  // Tag del objeto que activa el halo

    private void Start()
    {
        if (haloObject != null)
        {
            haloObject.SetActive(false); // Asegura que el halo empiece oculto
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && haloObject != null)
        {
            haloObject.SetActive(true); // Mostrar el halo
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag) && haloObject != null)
        {
            haloObject.SetActive(false); // Ocultar el halo
        }
    }
}