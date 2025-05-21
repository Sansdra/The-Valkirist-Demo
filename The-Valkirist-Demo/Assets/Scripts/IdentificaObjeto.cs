using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class IdentificaObjeto : MonoBehaviour
{
  private Camera cam;

  GameObject erin;
  public float rayDistance = 100;

  public float asd = 0.5f;
  public float qwe = 0.5f;


  public LayerMask Objeto;
  void Start()
  {


    cam = GetComponent<Camera>();
    if (cam == null)
    {
        cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("No se pudo encontrar la cámara");
            enabled = false;
            return;
        }
    }


    GameObject erin = GameObject.FindWithTag("Player");
  }


  void Update()
  {

    if (cam == null) return;

    Ray ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth/ 2f, cam.pixelHeight / 2f, 0f));
        RaycastHit hit;

        // Dibuja siempre el rayo para depuración, independientemente de si golpea o no
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.magenta, 0.1f); // Duración corta para no saturar

        bool getHit = Physics.Raycast(ray, out hit, rayDistance, Objeto);

        if (getHit)
        {
            Debug.Log("Hay un Objeto: " + hit.collider.name);
            if (hit.collider.CompareTag("Mesa")) // Es más eficiente usar CompareTag que == para tags
            {
                Debug.Log("Mi querida mesa, cuantas horas dibujando...");
                // Aquí podrías hacer algo con hit.collider.gameObject si lo necesitas
            }
        }
        else
        {
            // Opcional: Si quieres un color diferente cuando no golpea nada
            // Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.white, 0.1f);
            // Debug.Log("No se detectó ningún objeto en la LayerMask especificada.");
        }
    /*
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));
        RaycastHit hit;

        bool getHit = Physics.Raycast(ray, out hit, rayDistance, Objeto);
        Debug.DrawRay(ray.origin, ray.direction, Color.magenta);


        if (getHit)
        {

          Debug.Log("Hay un Objeto"); Debug.Log(hit.collider.name);
          if (hit.collider.tag == "Mesa")
          {
            Debug.Log("Mi querida mesa, cuantas horas dibujando...");
          }
        }
        else
        {
          Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.white);

        }
        */
    


  }
}
