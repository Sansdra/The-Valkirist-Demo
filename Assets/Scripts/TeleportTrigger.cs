using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public string escenaDestino = "EscenaDestino";
    public string puntoEntrada = "Entry";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GestorTeletransporteRobusto.Instancia.Teletransportar(escenaDestino, puntoEntrada);
        }
    }
}
