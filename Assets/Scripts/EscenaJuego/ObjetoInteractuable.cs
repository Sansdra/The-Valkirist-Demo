using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjetoRitmoInteractuable : MonoBehaviour, IInteractuable
{
    public string nombreEscenaRitmo = "EscenaRitmo";

    public string MensajeInteractuar()
    {
        return "Presiona E para jugar";
    }

    public void Interactuar()
    {
        Debug.Log("Activando escena de ritmo...");
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Destroy(player);
        }
        SceneTransitionManager.Instance.GoToScene("TutorialScene");
    }
}
