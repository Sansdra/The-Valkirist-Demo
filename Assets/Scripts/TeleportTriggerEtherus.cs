using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportTriggerEtherus : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Etherus");
        }
    }
}
