using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamaraSigue : MonoBehaviour {

	public Transform player;
	public Vector3 camOffset;

	[Range(0.1f, 1.0f)]
	public float SmoothFactor = 0.1f;

	public bool rotacionActive;
    public float velRotacion = 5.0f;

	public static bool lookAtPlayer = false;

	

	void Start()
	{
		camOffset = transform.position - player.position;
	}

	void FixedUpdate()
	{
		if(rotacionActive)
		{
			Quaternion camTurnAnlge =
				Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velRotacion, Vector3.up);
			
			camOffset = camTurnAnlge * camOffset;
		}


		Vector3 newPos = player.position + camOffset;

		transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

		if (lookAtPlayer || rotacionActive)
		{ 
			transform.LookAt(player); 
		}

		if (Input.GetButton("Fire1"))
		{
			rotacionActive = true;
		}
		else
		{
			rotacionActive = false;
			transform.LookAt(player);
		}
	}

}