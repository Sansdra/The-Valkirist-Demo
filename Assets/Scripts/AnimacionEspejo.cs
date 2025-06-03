using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimacionEspejo : MonoBehaviour, IInteractuable
{
    [Header("Animación de Imagen")]
    public Sprite[] animationFrames;
    public float frameDuration = 0.1f;
    public Image targetImage;

    [Header("Audio")]
    public AudioClip sonidoEspecial;
    public int frameConSonido = 2; // Índice del frame que reproduce sonido (empieza en 0)
    public AudioSource audioSource;

    private bool isPlaying = false;
    private Coroutine animationCoroutine;

    public string MensajeInteractuar()
    {
        return "Presiona E para interactuar";
    }

    public void Interactuar()
    {
        if (animationFrames.Length == 0 || targetImage == null)
        {
            Debug.LogWarning("Faltan sprites o la imagen no está asignada.");
            return;
        }

        if (!isPlaying)
        {
            animationCoroutine = StartCoroutine(PlayImageAnimation());
        }
        else
        {
            Debug.Log("La animación ya está en progreso.");
        }
    }

    private IEnumerator PlayImageAnimation()
    {
        isPlaying = true;
        targetImage.enabled = true;

        for (int i = 0; i < animationFrames.Length; i++)
        {
            targetImage.sprite = animationFrames[i];

            if (i == frameConSonido && sonidoEspecial != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoEspecial);
            }

            yield return new WaitForSeconds(frameDuration);
        }

        targetImage.enabled = false;
        isPlaying = false;

        OnAnimationFinished();
    }

    private void OnAnimationFinished()
    {
        Debug.Log("Animación espejo finalizada.");
        // Aquí podrías disparar otros eventos si lo necesitas
    }
}
