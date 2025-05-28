using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VueltaHabitacion : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneTransitionManager.Instance.GoToScene("Habitacion");
        }
    }
}
