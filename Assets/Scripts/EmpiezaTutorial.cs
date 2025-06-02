using System;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmpiezaTutorial : MonoBehaviour, IInteractuable
{

    public string MensajeInteractuar()
    {
        return "Presiona E para interactuar";
    }

    public void Interactuar()
    {
        Debug.Log("¡Interactuando con la mesa!");
        TocaTutorial();
        
       
        
    }

    public void TocaTutorial()
    {

        if (AgarraViolin.DestruirViolin == true)
        {  
            
            SceneManager.LoadScene("TutorialScene");
        }
    }
}
