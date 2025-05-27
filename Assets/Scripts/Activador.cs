using UnityEngine;

public class ActivadorTeleport : MonoBehaviour
{
    [Tooltip("Referencia al componente TeleportTrigger que se activará")]
    public TeleportTrigger teleportTrigger;

    [Tooltip("También puedes activar el GameObject completo si lo necesitas")]
    public GameObject teleportObject;

    public void ActivarTeleport()
    {
        if (teleportTrigger != null)
        {
            teleportTrigger.enabled = true;
            Debug.Log("✅ TeleportTrigger activado por script.");
        }

        if (teleportObject != null)
        {
            teleportObject.SetActive(true);
            Debug.Log("✅ GameObject del teleport activado.");
        }

        if (teleportTrigger == null && teleportObject == null)
        {
            Debug.LogWarning("⚠️ No se asignó ningún TeleportTrigger ni GameObject.");
        }
    }
}
