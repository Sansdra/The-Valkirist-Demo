using UnityEngine;
using System.Collections;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSystem dialogueSystem; // Referencia al sistema
    public DialogueSystem.DialogueLine[] lineasDialogo;

    private bool yaActivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (yaActivado) return;

        if (other.CompareTag("Player"))
        {
            yaActivado = true;
            StartCoroutine(DispararDialogo());
        }
    }

    IEnumerator DispararDialogo()
    {
        dialogueSystem.StartDialogue(lineasDialogo);

        // Esperar a que se terminen de escribir todas las líneas
        while (dialogueSystem.IsDialogoActivo())
        {
            yield return null;
        }

        // Cierra el diálogo automáticamente
        dialogueSystem.ForzarCierre();
    }
}
