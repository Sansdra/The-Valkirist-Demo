using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine;
using UnityEngine;

public class LookAt : MonoBehaviour
{
  GameObject erin = GameObject.FindWithTag("Player") ;

    public Transform target;
    public GameObject targetGameObject;  

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Space"))
        {  
            this.transform.LookAt(target);
        }
    }
}
