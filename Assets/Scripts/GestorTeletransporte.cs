using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestorTeletransporteRobusto : MonoBehaviour
{
    public static GestorTeletransporteRobusto Instancia;

    [Header("Referencias")]
    public GameObject jugadorRaiz; // El GameObject padre (ej: ErinRoot)
    public Image fadeImage;
    public float duracionFade = 1f;

    private string siguientePuntoEntrada = "";

    private void Awake()
    {
        if (Instancia != null && Instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        Instancia = this;
        DontDestroyOnLoad(gameObject);

        if (jugadorRaiz != null)
        {
            DontDestroyOnLoad(jugadorRaiz);
        }
    }

    public void Teletransportar(string nombreEscena, string puntoEntrada)
    {
        siguientePuntoEntrada = puntoEntrada;
        StartCoroutine(Transicion(nombreEscena));
    }

    private IEnumerator Transicion(string nombreEscena)
    {
        yield return Fade(Color.clear, Color.black);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nombreEscena);
        while (!asyncLoad.isDone) yield return null;

        yield return new WaitForSeconds(0.2f);

        ColocarEnPuntoEntrada();

        yield return Fade(Color.black, Color.clear);
    }

    private void ColocarEnPuntoEntrada()
    {
        GameObject punto = GameObject.Find(siguientePuntoEntrada);
        if (punto == null)
        {
            Debug.LogError("❌ Punto de entrada no encontrado: " + siguientePuntoEntrada);
            return;
        }

        CharacterController cc = jugadorRaiz.GetComponentInChildren<CharacterController>();
        if (cc != null) cc.enabled = false;

        jugadorRaiz.transform.position = punto.transform.position;
        jugadorRaiz.transform.rotation = punto.transform.rotation;

        if (cc != null) cc.enabled = true;
    }

    private IEnumerator Fade(Color desde, Color hasta)
    {
        if (fadeImage == null)
        {
            Debug.LogWarning("⚠️ No hay FadeImage asignado.");
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
