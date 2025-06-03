using UnityEngine;

public class InteractuaAmber : MonoBehaviour, IInteractuable
{
    public DialogueSystem.DialogueLine[] lineasDialogo;
    [Header("Referencias")]
public DialogueSystem sistema;


    public string MensajeInteractuar()
    {
        return "Presiona E para hablar";
    }

    public void Interactuar()
    {

        DialogueSystem sistema = FindObjectOfType<DialogueSystem>();
        if (sistema != null)
        {
            sistema.StartDialogue(lineasDialogo); // AQUÍ es donde va la línea
        }
        else
        {
            Debug.LogWarning("No se encontró DialogueSystem en la escena.");
        }
    }
}