using UnityEngine;

public class ObjetoRitmoInteractuable : MonoBehaviour, IInteractuable
{
    public string nombreEscenaRitmo = "EscenaRitmo";

    public string MensajeInteractuar()
    {
        return "Presiona E para jugar";
    }

    public void Interactuar()
    {
        Debug.Log("Activando escena de ritmo...");
        EscenaRitmoLoader.Instancia.ActivarEscenaRitmo(nombreEscenaRitmo);
    }
}
