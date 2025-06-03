using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscenaTrasTiempo : MonoBehaviour
{
    [Header("Configuración")]
    public string nombreEscena = "NombreDeTuEscena";
    public float tiempoDeEspera = 5f;

    void Start()
    {
        Invoke(nameof(CargarEscena), tiempoDeEspera);
    }

    void CargarEscena()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
