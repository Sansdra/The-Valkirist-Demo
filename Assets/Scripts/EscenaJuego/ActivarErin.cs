using UnityEngine;
using UnityEngine.SceneManagement;

public class RecargarHabitacion : MonoBehaviour
{
    public string nombreEscena = "Habitacion";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1f; // <- muy importante
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
