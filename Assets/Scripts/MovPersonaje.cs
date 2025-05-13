using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    private Animator anim;

    public float velocidMovimiento = 10.0f;
    public float velocidRotacion = 200.0f;

   public bool corriendo;

    public float x, y;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidRotacion,0);
        transform.Translate(0,0, y * Time.deltaTime * velocidMovimiento);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        corriendo = Input.GetKey(KeyCode.LeftShift);

        if(corriendo == true){
            velocidMovimiento = 100.0f;
            
        }else{
            velocidMovimiento = 10.0f;
        }
    }
}
