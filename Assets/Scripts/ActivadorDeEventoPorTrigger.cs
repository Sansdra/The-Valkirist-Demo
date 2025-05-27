using UnityEngine;

public class ActivadorDeEventoPorTrigger : MonoBehaviour
{
    [Header("Referencias opcionales")]
    public Light luzAEncender;
    public AudioSource sonidoAReproducir;

    [Tooltip("Tag del jugador que activa el evento")]
    public string tagJugador = "Player";

    private void Start()
    {
        // Asegura que la luz esté apagada al iniciar
        if (luzAEncender != null)
        {
            luzAEncender.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagJugador))
        {
            if (luzAEncender != null)
                luzAEncender.enabled = true;

            if (sonidoAReproducir != null && !sonidoAReproducir.isPlaying)
                sonidoAReproducir.Play();
        }
    }
}
