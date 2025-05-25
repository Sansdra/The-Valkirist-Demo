using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< HEAD:Assets/Scripts/GameController.cs
public class GameController : MonoBehaviour
========
public class DontDestroyOnLoad : MonoBehaviour
>>>>>>>> 72168df012b730fc6774fc99e1ee197d41545ba6:The-Valkirist-Demo/Assets/Scripts/DontDestroyOnLoad.cs
{
    // Start is called before the first frame update
    void Start()
    {
<<<<<<<< HEAD:Assets/Scripts/GameController.cs
    
========

        {
            DontDestroyOnLoad(gameObject);
        }

>>>>>>>> 72168df012b730fc6774fc99e1ee197d41545ba6:The-Valkirist-Demo/Assets/Scripts/DontDestroyOnLoad.cs
    }

    // Update is called once per frame
    void Update()
    {

    }
}
