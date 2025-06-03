using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JudgementDisplay : MonoBehaviour
{
    [Header("Referencias")]
    public TextMeshProUGUI judgementText;
    public Animator animator; // Animator con animaciones "Show" y "Hide"

    [Header("Colores por Tipo")]
    public Color perfectColor = Color.yellow;
    public Color goodColor = Color.green;
    public Color okColor = Color.cyan;
    public Color missColor = Color.red;

    [Header("Tiempo de Display")]
    public float displayTime = 0.6f;

    private Coroutine displayRoutine;

    void Start()
    {
        if (judgementText == null)
        {
            Debug.LogWarning("JudgementDisplay: No se asignó TextMeshProUGUI.");
        }
        if (animator == null)
        {
            Debug.LogWarning("JudgementDisplay: No se asignó Animator.");
        }
        judgementText.gameObject.SetActive(false);
    }

    /// <summary>
    /// Mostrar el texto con color y animación según tipo.
    /// </summary>
    /// <param name="text">Texto visible (ej: "Perfect")</param>
    /// <param name="type">Tipo en minúsculas para definir color/animación (ej: "perfect")</param>
public void ShowJudgement(string text, string type)
{
    if (judgementText == null) return;

    judgementText.text = text;

    // Asignar color según tipo
    switch (type.ToLower())
    {
        case "perfect":
            judgementText.color = perfectColor;
            break;
        case "good":
            judgementText.color = goodColor;
            break;
        case "ok":
            judgementText.color = okColor;
            break;
        case "miss":
            judgementText.color = missColor;
            break;
        default:
            judgementText.color = Color.white;
            break;
    }

    // 🌀 Iniciar la onda estética
    judgementText.GetComponent<JudgementTextWave>()?.StartWave(displayTime + 0.5f);

    judgementText.gameObject.SetActive(true);

    if (displayRoutine != null)
        StopCoroutine(displayRoutine);

    displayRoutine = StartCoroutine(DisplaySequence());
}


    private IEnumerator DisplaySequence()
    {
        if (animator != null)
        {
            animator.Play("Show");
        }

        yield return new WaitForSeconds(displayTime);

        if (animator != null)
        {
            animator.Play("Hide");
        }

        // Esperar que la animación de hide termine antes de ocultar el texto
        float hideAnimDuration = 0.5f; // Ajusta según duración de la animación "Hide"
        yield return new WaitForSeconds(hideAnimDuration);

        judgementText.gameObject.SetActive(false);
    }
}
