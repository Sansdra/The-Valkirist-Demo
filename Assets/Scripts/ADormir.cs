using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ADormir : MonoBehaviour, IInteractuable
{
    public string nombreEscenaDestino;
    public Image fadeImage;
    public float duracionFade = 1.5f;
    private bool yaFueUsado = false;

    public void Interactuar()
    {
        if (!yaFueUsado)
        {
            yaFueUsado = true;
            GameObject.FindObjectOfType<MonoBehaviour>().StartCoroutine(FadeYEscena());
        }
    }

    public string MensajeInteractuar()
    {
        return yaFueUsado ? "" : "Presiona E para cambiar de escena";
    }

    IEnumerator FadeYEscena()
    {
        // Fade out (oscurecer)
        float t = 0f;
        while (t < duracionFade)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Clamp01(t / duracionFade);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        // Cargar nueva escena
        yield return SceneManager.LoadSceneAsync(nombreEscenaDestino);

        // Fade in (aclarar)
        t = 0f;
        while (t < duracionFade)
        {
            t += Time.deltaTime;
            float alpha = 1f - Mathf.Clamp01(t / duracionFade);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
