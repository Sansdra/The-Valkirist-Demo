using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTrigger : MonoBehaviour
{
    public string escenaDestino = "EscenaDestino";
    public string puntoEntrada = "Entry";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Pasillo");
        }
    }
}
