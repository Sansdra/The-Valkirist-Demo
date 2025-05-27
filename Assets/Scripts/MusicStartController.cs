using UnityEngine;
using System.Collections;

public class MusicStartController : MonoBehaviour
{
    public AudioSource musicSource;
    public float delayBeforeStart = 0.2f; // Pequeño delay para que spawners carguen

    IEnumerator Start()
    {
        yield return new WaitForSeconds(delayBeforeStart);

        // Esperar a que todos los spawners estén listos

        yield return new WaitForEndOfFrame(); // un frame extra para evitar frames perdidos
        musicSource.Play();
    }
}
