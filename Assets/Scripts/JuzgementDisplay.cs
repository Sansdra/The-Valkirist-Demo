using UnityEngine;
using UnityEngine.UI;  // O usar TMPro si tienes TextMeshPro
using System.Collections;
using TMPro;

public class JudgementDisplay : MonoBehaviour
{
    public TMP_Text judgementText;
  // Arrastra tu UI Text aquí desde el inspector

    public float displayDuration = 1f;  // Tiempo que el texto se mantiene visible
    public float fadeDuration = 0.5f;   // Tiempo del fade out

    private Coroutine currentCoroutine;

    void Start()
    {
        judgementText.text = "";
        judgementText.color = new Color(judgementText.color.r, judgementText.color.g, judgementText.color.b, 0f);
    }

    public void ShowJudgement(string message)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(ShowAndFade(message));
    }

    private IEnumerator ShowAndFade(string message)
    {
        // Mostrar texto al máximo alfa
        judgementText.text = message;
        Color color = judgementText.color;
        color.a = 1f;
        judgementText.color = color;

        // Esperar el tiempo de display sin opacidad reducida
        yield return new WaitForSeconds(displayDuration);

        // Hacer fade out progresivo
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);
            color.a = alpha;
            judgementText.color = color;
            yield return null;
        }

        // Finalmente dejar el texto invisible
        judgementText.text = "";
    }
}
