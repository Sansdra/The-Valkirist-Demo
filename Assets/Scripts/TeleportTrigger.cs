using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public string escenaDestino = "EscenaDestino";
    public string puntoEntrada = "Entry";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate que tu jugador tenga el tag "Player"
        {
            GestorTeletransporte.Instancia.Teletransportar(escenaDestino, puntoEntrada);
        }
    }
}
