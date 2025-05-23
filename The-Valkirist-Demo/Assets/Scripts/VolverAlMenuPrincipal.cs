using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAlMenuPrincipal : MonoBehaviour
{
    [Tooltip("Nombre exacto de la escena del menú principal")]
    public string nombreEscenaMenu = "Inicio";

    [Tooltip("Animator con la animación de salida (ej. fade out)")]
    public Animator animadorTransicion;

    [Tooltip("Nombre del trigger que inicia la animación de salida")]
    public string triggerSalida = "Salir";

    public float duracionTransicion = 1f;

    public void VolverAlMenu()
    {
        if (animadorTransicion != null)
        {
            animadorTransicion.SetTrigger(triggerSalida);
            Invoke(nameof(CargarEscena), duracionTransicion);
        }
        else
        {
            // Por si no hay animador asignado, carga directamente
            CargarEscena();
        }
    }

    void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}
