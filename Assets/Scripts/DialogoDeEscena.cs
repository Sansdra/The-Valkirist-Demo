using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogoDeEscena : MonoBehaviour
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

    void Start()
    {
        IniciarDialogo();
    }
    public void IniciarDialogo()
    {

        sistema.StartDialogue(lineasDialogo);

        CargaEscenaFinal();

    }

    IEnumerator CargaEscenaFinal()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("EscenaGanaTexto");
    }
}
