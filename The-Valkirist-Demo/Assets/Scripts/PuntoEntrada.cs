using UnityEngine;

public class PuntoEntrada : MonoBehaviour
{
    [Tooltip("Nombre único para identificar este punto de entrada.")]
    public string nombrePuntoEntrada;

    private void Awake()
    {
        // Renombra automáticamente el GameObject para que sea fácil encontrarlo con GameObject.Find
        if (!string.IsNullOrEmpty(nombrePuntoEntrada))
        {
            gameObject.name = nombrePuntoEntrada;
        }
        else
        {
            Debug.LogWarning("⚠️ No se asignó un nombre al PuntoEntrada.");
        }
    }
}
