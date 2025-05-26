using UnityEngine;
using UnityEngine.UI;

public class IdentificaObjeto : MonoBehaviour
{
    public float rayDistance = 35f;
    public LayerMask objetoLayer;
    public Text textoInteraccion;

    private Camera cam;
    private GameObject erin;
    private IInteractuable objetoActual;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            cam = Camera.main;
            if (cam == null)
            {
                Debug.LogError("No se pudo encontrar la cámara.");
                enabled = false;
                return;
            }
        }

        erin = GameObject.FindWithTag("Player");
        if (erin == null)
        {
            Debug.LogWarning("No se encontró al jugador con tag 'Player'");
        }

        if (textoInteraccion != null)
            textoInteraccion.enabled = false;
    }

    void Update()
    {
        DetectarObjeto();

        if (objetoActual != null && Input.GetKeyDown(KeyCode.E))
        {
            objetoActual.Interactuar();
        }
    }

    void DetectarObjeto()
    {
        objetoActual = null;
        if (textoInteraccion != null) textoInteraccion.enabled = false;

        Ray ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth / 2f, cam.pixelHeight / 2f));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.magenta, 0.1f);

        if (Physics.Raycast(ray, out hit, rayDistance, objetoLayer))
        {
            GameObject objetoDetectado = hit.collider.gameObject;
            Debug.Log("Objeto detectado: " + objetoDetectado.name);

            IInteractuable interactuable = objetoDetectado.GetComponent<IInteractuable>();
            if (interactuable != null)
            {
                objetoActual = interactuable;
                if (textoInteraccion != null)
                {
                    textoInteraccion.text = objetoActual.MensajeInteractuar();
                    textoInteraccion.enabled = true;
                }
            }
        }
    }
}
