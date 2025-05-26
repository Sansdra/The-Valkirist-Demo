using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class MovPersonaje : MonoBehaviour
{
    private Animator anim;

    public float velocidMovimiento = 10.0f;
    public float velocidRotacion = 200.0f;

    //public bool MiraPers = CamaraSigue.lookAtPlayer;
    public bool corriendo;



    public float x, y;

    public bool quieto;
    void Start()
    {
        anim = GetComponent<Animator>();
        GameObject camaraMira = GameObject.FindWithTag("MainCamera");
        GameObject lookAt = GameObject.FindWithTag("LookAt");

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidRotacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        corriendo = Input.GetKey(KeyCode.LeftShift);

        if (corriendo == true)
        {
            velocidMovimiento = 100.0f;

        }
        else
        {
            velocidMovimiento = 10.0f;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            
        }
    }

}
