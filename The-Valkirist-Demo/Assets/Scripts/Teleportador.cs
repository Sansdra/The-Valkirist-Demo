using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Teleportador : MonoBehaviour
{
    public string nombreEscenaDestino;
    public string nombrePuntoEntrada = "PuntoEntrada";

    public GameObject jugador;
    public GameObject camara;

    private void Start()
    {
        // Evita que se destruyan al cambiar de escena
        DontDestroyOnLoad(jugador);
        DontDestroyOnLoad(camara);
        DontDestroyOnLoad(gameObject); // este script también
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.LoadScene(nombreEscenaDestino);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        StartCoroutine(RecolocarJugadorTrasCargar());
    }

    IEnumerator RecolocarJugadorTrasCargar()
    {
        yield return new WaitForSeconds(0.1f); // Espera breve para asegurar que el suelo esté cargado

        GameObject puntoEntrada = GameObject.Find(nombrePuntoEntrada);
        if (puntoEntrada != null && jugador != null)
        {
            // Desactiva temporalmente el CharacterController si lo hay
            CharacterController controller = jugador.GetComponent<CharacterController>();
            if (controller != null)
                controller.enabled = false;

            jugador.transform.position = puntoEntrada.transform.position;
            jugador.transform.rotation = puntoEntrada.transform.rotation;

            if (controller != null)
            {
                yield return null;
                controller.enabled = true;
            }
        }
        else
        {
            Debug.LogWarning("No se encontró el PuntoEntrada o el jugador.");
        }
    }
}
