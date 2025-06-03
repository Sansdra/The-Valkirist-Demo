using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogoDeEscena : MonoBehaviour
{
    [Header("Diálogo")]
    public DialogueSystem.DialogueLine[] lineasDialogo;

    [Header("Fade")]
    public Image fadeImage;
    public float fadeDuration = 1f;
    public float delayAfterFade = 0.3f; // Pausa después del fade, antes de cambiar de escena

    private DialogueSystem sistema;

    void Awake()
    {
        sistema = FindObjectOfType<DialogueSystem>();
        if (sistema == null)
        {
            Debug.LogWarning("No se encontró DialogueSystem en la escena.");
        }

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }
    }

    void Start()
    {
        IniciarDialogo();
    }

    public void IniciarDialogo()
    {
        if (sistema != null)
        {
            sistema.StartDialogue(lineasDialogo);
            StartCoroutine(EsperarFinDialogoYCambiarEscena());
        }
    }

    IEnumerator EsperarFinDialogoYCambiarEscena()
    {
        // Esperar a que termine el diálogo
        while (sistema.IsDialogoActivo())
            yield return null;

        // Esperar un segundo antes de empezar el fade (con Time.timeScale = 0)
        yield return new WaitForSecondsRealtime(1f);

        if (fadeImage != null)
        {
            yield return StartCoroutine(FadeToBlack());
        }

        // Espera después del fade para asegurar visualización completa
        yield return new WaitForSecondsRealtime(delayAfterFade);

        SceneManager.LoadScene("EscenaGanaTexto");
    }

    IEnumerator FadeToBlack()
    {
        float elapsed = 0f;
        Color c = fadeImage.color;

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            c.a = Mathf.Lerp(0f, 1f, t);
            fadeImage.color = c;
            elapsed += Time.unscaledDeltaTime; // usar tiempo real aunque el juego esté pausado
            yield return null;
        }

        // Asegurar alpha final
        c.a = 1f;
        fadeImage.color = c;
    }
}
