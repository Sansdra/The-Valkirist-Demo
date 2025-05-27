using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AltairInteractuable : MonoBehaviour, IInteractuable
{
    public string nombreBatallaRitmo = "EscenaBatalla";

    public string MensajeInteractuar()
    {
        return "Presiona E para salvarte";
    }

    public void Interactuar()
    {
        Debug.Log("Activando batalla...");
        SceneManager.LoadScene("FightScene");
    }
}
