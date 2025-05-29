using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjetoInteractuableFinalFight : MonoBehaviour, IInteractuable
{
    public string nombreEscenaRitmo = "FightScene";

    

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
            SceneManager.LoadScene(nombreEscenaRitmo);
            
        }
        
    }
        //EscenaRitmoLoader.Instancia.ActivarEscenaRitmo("TutorialScene");
}
