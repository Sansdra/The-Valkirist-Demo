using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MesaInteractuableConImagen : MonoBehaviour, IInteractuable
{
    [Header("Diálogo")]
    public DialogueSystem.DialogueLine[] lineasDialogo;

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
            StartCoroutine(AnimarYDialogar());
        }
        else
        {
            // Si no hay imagen, solo lanza el diálogo normal
            Debug.Log("No hay animación, iniciando diálogo directamente.");
            IniciarDialogo();
        }
    }

    private IEnumerator AnimarYDialogar()
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

        IniciarDialogo();
    }

    private void IniciarDialogo()
    {
        DialogueSystem sistema = FindObjectOfType<DialogueSystem>();
        if (sistema != null)
        {
            sistema.StartDialogue(lineasDialogo);
        }
        else
        {
            Debug.LogWarning("No se encontró DialogueSystem en la escena.");
        }
    }
}
