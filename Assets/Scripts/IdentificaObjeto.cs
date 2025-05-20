using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdentificaObjeto : MonoBehaviour
{
  Camera cam;

  public float rayDistance = 100;

  public float asd = 0.5f;
  public float qwe = 0.5f;
  

public LayerMask layerMask;
  void Start()
  {
    cam = Camera.main;
  }


  void FixedUpdate()
  {
    Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
    RaycastHit hit;


    if (Physics.Raycast(ray, out hit, rayDistance))
    {
      Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.magenta);
      Debug.Log("Hay un Objeto"); Debug.Log(hit.collider.name);
      
    }
    else
    {
      Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.white);

    }
  }
}
