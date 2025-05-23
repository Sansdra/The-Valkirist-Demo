using UnityEngine;

public class MesaInteractuable : MonoBehaviour, IInteractuable
{
    public DialogueSystem.DialogueLine[] lineasDialogo;

    public string MensajeInteractuar()
    {
        return "Presiona E para mirar la mesa";
    }

    public void Interactuar()
    {
        Debug.Log("¡Interactuando con la mesa!");

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
