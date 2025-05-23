using UnityEngine;

public class MesaInteractuable : MonoBehaviour, IInteractuable
{
    public void Interactuar()
    {
        Debug.Log("Interacción con la mesa: ¡cuántas horas dibujando!");
    }

    public string MensajeInteractuar()
    {
        return "Pulsa E para recordar la mesa";
    }
}
