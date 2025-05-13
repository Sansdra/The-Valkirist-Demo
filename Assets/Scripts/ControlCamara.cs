using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{


    public GameObject jugador;


    private Vector3 offset;

    void Start()
    {

        offset = transform.position - jugador.transform.position;


    }


    void LateUpdate()
    {


        transform.position = jugador.transform.position + offset;

    }
}