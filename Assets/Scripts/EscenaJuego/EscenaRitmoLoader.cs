using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EscenaRitmoLoader : MonoBehaviour
{
    public static EscenaRitmoLoader Instancia;

    private Camera camaraRitmo;
    private GameObject escenaPrincipal;

    void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActivarEscenaRitmo(string nombreEscena)
    {
        StartCoroutine(CargarEscena(nombreEscena));
    }

    IEnumerator CargarEscena(string nombre)
    {
        escenaPrincipal = SceneManager.GetActiveScene().GetRootGameObjects()[0].transform.root.gameObject;
        escenaPrincipal.SetActive(false);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nombre, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
            yield return null;

        Scene escenaRitmo = SceneManager.GetSceneByName(nombre);
        foreach (GameObject go in escenaRitmo.GetRootGameObjects())
        {
            camaraRitmo = go.GetComponentInChildren<Camera>();
            if (camaraRitmo != null) break;
        }

        if (camaraRitmo != null)
        {
            camaraRitmo.enabled = true;
        }
        else
        {
            Debug.LogWarning("No se encontró cámara en la escena secundaria.");
        }
    }

    public void VolverAEscenaPrincipal(string nombreEscenaRitmo)
    {
        StartCoroutine(UnloadEscena(nombreEscenaRitmo));
    }

    IEnumerator UnloadEscena(string nombre)
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(nombre);
        while (!asyncUnload.isDone)
            yield return null;

        escenaPrincipal.SetActive(true);
    }
}
