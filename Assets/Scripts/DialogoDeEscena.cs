    using UnityEngine;

public class DialogoDeEscena : MonoBehaviour
{
    [Header("Diálogo")]
    public DialogueSystem1Scene.DialogueLine[] lineasDialogo;

    private DialogueSystem1Scene sistema;

    void Awake()
    {
        sistema = FindObjectOfType<DialogueSystem1Scene>();
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
        
            sistema.StartDialogueNoSystem(lineasDialogo);
        
    }
}
