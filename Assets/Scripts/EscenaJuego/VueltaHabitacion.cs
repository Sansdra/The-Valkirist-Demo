using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VueltaHabitacion : MonoBehaviour
{
    


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape ))
        {
            SceneManager.LoadScene("HabitacionDespuesDeAtril");
        }
    }
}
