using UnityEngine;
using UnityEngine.UI;

public class IdentificadorInteraccion : MonoBehaviour
{
    public float distancia = 3f;
    public LayerMask capaObjetos;
    public Text textoInteraccion;

    private Camera cam;
    private GameObject jugador;
    private IInteractuable actualInteractuable;

    void Start()
    {
        cam = Camera.main;
        jugador = GameObject.FindWithTag("Player");

        if (textoInteraccion != null)
            textoInteraccion.enabled = false;
    }

    void Update()
    {
        {
            DetectarInteractuable();

            if (actualInteractuable != null && Input.GetKeyDown(KeyCode.E))
            {
                actualInteractuable.Interactuar();
            }
        }


        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red);
            Debug.Log("Ray lanzado desde el centro de la cámara");
        }

    }

    void DetectarInteractuable()
    {
        textoInteraccion.enabled = false;
        actualInteractuable = null;

        Ray rayo = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));

        Debug.DrawRay(rayo.origin, rayo.direction * distancia, Color.magenta);

        if (Physics.Raycast(rayo, out RaycastHit hit, distancia, capaObjetos))
        {
            GameObject obj = hit.collider.gameObject;

            float dist = Vector3.Distance(jugador.transform.position, obj.transform.position);

            IInteractuable interactuable = obj.GetComponent<IInteractuable>();
            if (interactuable != null && dist <= distancia)
            {
                actualInteractuable = interactuable;
                textoInteraccion.text = interactuable.MensajeInteractuar();
                textoInteraccion.enabled = true;
            }
            Debug.Log("Estoy lanzando el rayo...");

        }


    }

}
