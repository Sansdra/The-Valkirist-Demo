using UnityEngine;

public class AutoDialogoSinMesa : MonoBehaviour
{
    public DialogoDeEscena DialogoDeEscena;

    void Start()
    {
        if (DialogoDeEscena != null)
        {
            DialogoDeEscena.IniciarDialogo();
        }
        else
        {
            Debug.LogWarning("DialogoEscena no se asigno");
        }
    }
}
