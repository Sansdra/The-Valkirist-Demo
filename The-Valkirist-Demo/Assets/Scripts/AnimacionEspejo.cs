using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AnimacionEspejo : MonoBehaviour, IInteractuable
{
    [Header("Animación de Imagen")]
    public Sprite[] animationFrames;
    public float frameDuration = 0.1f;
    public Image targetImage;

    private bool isPlaying = false;

    public string MensajeInteractuar()
    {
        return "Presiona E para interactuar";
    }

    public void Interactuar()
    {
        if (!isPlaying && animationFrames.Length > 0 && targetImage != null)
        {
            StartCoroutine(PlayImageAnimation());
        }
        else
        {
            Debug.LogWarning("Faltan sprites o la imagen no está asignada.");
        }
    }

    private IEnumerator PlayImageAnimation()
    {
        isPlaying = true;
        targetImage.enabled = true;

        foreach (Sprite frame in animationFrames)
        {
            targetImage.sprite = frame;
            yield return new WaitForSeconds(frameDuration);
        }

        targetImage.enabled = false;
        isPlaying = false;
    }
}
