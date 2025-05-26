using UnityEngine;

public class AutoDialogo : MonoBehaviour
{
    public MesaInteractuable mesa;

    void Start()
    {
        if (mesa != null)
        {
            mesa.IniciarDialogo();
        }
        else
        {
            Debug.LogWarning("No se asignó la MesaInteractuable al activador.");
        }
    }
}
