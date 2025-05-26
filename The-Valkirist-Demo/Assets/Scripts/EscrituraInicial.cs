using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EscrituraInicial : MonoBehaviour
{
    [Header("Líneas de diálogo")]
    [TextArea(2, 5)]
    public string[] dialogos;

    [Header("Referencias UI (TextMeshPro)")]
    public TextMeshProUGUI textoUI;
    public TextMeshProUGUI textoContinuarUI;

    [Header("Velocidad de mecanografía")]
    public float velocidadEscritura = 0.05f;

    [Header("Sonido")]
    public AudioClip sonidoTecla;
    public float pitchAleatorio = 0.05f;

    [Header("Escena")]
    public bool cargarEscenaAlFinal = false;
    public string nombreEscenaACargar;

    private AudioSource audioSource;
    private int indiceDialogo = 0;
    private bool textoTerminado = false;

    void Start()
    {
        textoUI.text = "";
        textoContinuarUI.gameObject.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        if (dialogos.Length > 0)
        {
            StartCoroutine(MostrarTexto(dialogos[indiceDialogo]));
        }
        else
        {
            Debug.LogWarning("No hay diálogos asignados.");
        }
    }

    void Update()
    {
        if (textoTerminado && Input.GetKeyDown(KeyCode.E))
        {
            textoContinuarUI.gameObject.SetActive(false);
            textoTerminado = false;

            indiceDialogo++;

            if (indiceDialogo < dialogos.Length)
            {
                StartCoroutine(MostrarTexto(dialogos[indiceDialogo]));
            }
            else
            {
                Debug.Log("Fin del diálogo.");

                if (cargarEscenaAlFinal && !string.IsNullOrEmpty(nombreEscenaACargar))
                {
                    SceneManager.LoadScene(nombreEscenaACargar);
                }
            }
        }
    }

    IEnumerator MostrarTexto(string texto)
    {
        textoUI.text = "";

        foreach (char letra in texto)
        {
            textoUI.text += letra;

            if (sonidoTecla != null && audioSource != null)
            {
                audioSource.pitch = 1f + Random.Range(-pitchAleatorio, pitchAleatorio);
                audioSource.PlayOneShot(sonidoTecla);
            }

            yield return new WaitForSeconds(velocidadEscritura);
        }

        textoTerminado = true;
        textoContinuarUI.gameObject.SetActive(true);
    }
}
