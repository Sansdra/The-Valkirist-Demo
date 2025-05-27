using UnityEngine;

public class PartituraInteractuable : MonoBehaviour, IInteractuable
{
    [Header("Diálogo")]
    public DialogueSystem.DialogueLine[] lineasDialogo;

    private DialogueSystem sistema;

    void Awake()
    {
        sistema = FindObjectOfType<DialogueSystem>();
        if (sistema == null)
        {
            Debug.LogWarning("No se encontró DialogueSystem en la escena.");
        }
    }

    public string MensajeInteractuar()
    {
        return "Presiona E para interactuar";
    }

    public void Interactuar()
    {
        Debug.Log("¡Interactuando con la mesa!");
        IniciarDialogo();
        
       
        
    }

    /// <summary>
    /// Método público para iniciar el diálogo desde otro script (como al cargar la escena).
    /// </summary>
    public void IniciarDialogo()
    {
        if (sistema != null && lineasDialogo != null && lineasDialogo.Length > 0)
        {
            sistema.StartDialogue(lineasDialogo);

        }
        else
        {
            Debug.LogWarning("No se puede iniciar el diálogo: sistema nulo o sin líneas.");
        }
    }
}
