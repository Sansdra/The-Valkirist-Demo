using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EscenaRitmoLoader : MonoBehaviour
{
    public static EscenaRitmoLoader Instancia;


    public void ActivarEscenaRitmo(string nombreEscena)
    {
        StartCoroutine(CargarEscena(nombreEscena));
    }

    IEnumerator CargarEscena(string nombre)
    {

        SceneManager.LoadSceneAsync(nombre);

        yield return null;

    }

}
