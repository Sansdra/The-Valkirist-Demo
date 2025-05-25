using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestorTeletransporte : MonoBehaviour
{
    public static GestorTeletransporte Instancia;

    public GameObject jugador;
    public Image fadeImage; // UI negra para el fade
    public float duracionFade = 1f;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    public void Teletransportar(string nombreEscena, string nombrePuntoEntrada)
    {
        StartCoroutine(CambiarEscena(nombreEscena, nombrePuntoEntrada));
    }

    IEnumerator CambiarEscena(string nombreEscena, string nombrePuntoEntrada)
    {
        yield return IniciarFade(Color.clear, Color.black); // Fundido a negro

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nombreEscena);
        while (!asyncLoad.isDone)
            yield return null;

        yield return new WaitForSeconds(0.1f); // Espera corta

        yield return ColocarJugador(nombrePuntoEntrada);

        yield return IniciarFade(Color.black, Color.clear); // Fundido desde negro
    }

    IEnumerator ColocarJugador(string puntoEntrada)
    {
        if (jugador == null)
        {
            Debug.LogError("❌ El jugador no está asignado en el GestorTeletransporte.");
            yield break;
        }

        Transform punto = BuscarPuntoEntrada(puntoEntrada);
        if (punto == null)
        {
            Debug.LogError("❌ Punto de entrada no encontrado: " + puntoEntrada);
            yield break;
        }

        CharacterController controller = jugador.GetComponent<CharacterController>();
        if (controller != null) controller.enabled = false;

        jugador.transform.position = punto.position;
        jugador.transform.rotation = punto.rotation;

        yield return null;

        if (controller != null) controller.enabled = true;

        Debug.Log("✅ Jugador colocado en punto: " + puntoEntrada);
    }

    Transform BuscarPuntoEntrada(string nombrePunto)
    {
        GameObject obj = GameObject.Find(nombrePunto);
        if (obj == null)
        {
            Debug.LogError("❌ No se encontró el GameObject llamado: " + nombrePunto);
            return null;
        }
        return obj.transform;
    }

    IEnumerator IniciarFade(Color desde, Color hasta)
    {
        if (fadeImage == null)
        {
            Debug.LogWarning("⚠️ FadeImage no asignado. Saltando fundido.");
            yield break;
        }

        float t = 0f;
        while (t < duracionFade)
        {
            t += Time.deltaTime;
            fadeImage.color = Color.Lerp(desde, hasta, t / duracionFade);
            yield return null;
        }

        fadeImage.color = hasta;
    }
}
