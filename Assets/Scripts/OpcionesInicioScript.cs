using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcionesInicioScript : MonoBehaviour
{
    [Header("Referencias UI")]
    [SerializeField] private GameObject panelSettings;

    [Header("Animación de inicio")]
    [SerializeField] private float tiempoEsperaAnimacion = 0.65f;

    void Start()
    {
        if (panelSettings == null)
        {
            panelSettings = GameObject.Find("PanelSettings");
        }

        panelSettings?.SetActive(true); // Activa el panel si se encontró
    }

    public void StartGame()
    {
        StartCoroutine(WaitAnimationThenStart());
    }

    public void Options()
    {

        StartCoroutine(WaitAnimationThenStartOpt());
        
    }

    public void Exit()
    {
        StartCoroutine(WaitAnimationThenStartExit());
        
    }

    public void ExitGame()
    {
        #if !UNITY_EDITOR
            Application.Quit();
        #else
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void MostrarSettings()
    {
        panelSettings?.SetActive(true);
    }

    public void OcultarSettings()
    {
        panelSettings?.SetActive(false);
    }

    public void SuenaBoton()
    {
        // Aquí puedes agregar código para reproducir sonido del botón
        // Por ejemplo: AudioSource.PlayClipAtPoint(clip, transform.position);
    }

    private IEnumerator WaitAnimationThenStart()
    {
        Debug.Log("Esperando animación de inicio...");
        yield return new WaitForSeconds(tiempoEsperaAnimacion);
        Debug.Log("Animación terminada. Cargando escena...");
        SceneManager.LoadScene("Introduccion");
    }
    private IEnumerator WaitAnimationThenStartOpt()
    {
        Debug.Log("Esperando animación de inicio...");
        yield return new WaitForSeconds(tiempoEsperaAnimacion);
        Debug.Log("Animación terminada. Cargando escena...");
        SceneManager.LoadScene("Opciones");
    }
    private IEnumerator WaitAnimationThenStartExit()
    {
        
        yield return new WaitForSeconds(tiempoEsperaAnimacion);

        ExitGame();
    }
}
