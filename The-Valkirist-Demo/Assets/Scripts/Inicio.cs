using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InicioScript : MonoBehaviour
{

    GameObject panelSettings;



    // Start is called before the first frame update
    void Start()
    {
        panelSettings = GameObject.Find("PanelSettings");
        panelSettings.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
      StartCoroutine(waitAnimation());
       
    }
    public void Options()
    {
        SceneManager.LoadScene("Opciones");
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controles");
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

        panelSettings.SetActive(true);
    }

    public void OcultarSettings()
    {
        panelSettings.SetActive(false);
    }

    public void SuenaBoton()
    {

    }

    public IEnumerator waitAnimation()
    {
        Debug.Log("Esperando...");
        yield return new WaitForSeconds(0.6f);
        Debug.Log("Ya está");
         SceneManager.LoadScene("Etherus");  
    }
}
