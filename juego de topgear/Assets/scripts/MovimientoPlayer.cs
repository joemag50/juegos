﻿using UnityEngine;
using System.Collections;

public class MovimientoPlayer : MonoBehaviour
{
	//variables
	public float maxSpeed = 1;
	public bool  direccion = true;
	public float limitesCarro = 0.3f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Esta variable es la que se utiliza para moverse
		Vector3 pos = transform.position;
		//Debug.Log(Input.touchCount);
		//Debug.Log(Input.GetTouch(0).position);

		//Un dedo esta tocando
		if(Input.touchCount > 0)
		{
			//Acaba de iniciar a tocar la pantalla
			if(Input.GetTouch(0).phase  == TouchPhase.Began)
			{
				//Cambio en el movimiento
				if(direccion)
				{
					direccion = false;
				}
				else
				{
					direccion = true;
				}
			}
		}
		//movimiento
		if(direccion)
		{
			pos.x += maxSpeed * Time.deltaTime;
		}
		else
		{
			pos.x -= maxSpeed * Time.deltaTime;
		}

		//Este pedo es para que agarre los lados
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;

		//Limites de pantalla
		if((pos.x + limitesCarro) > widthOrtho)
		{
			pos.x = (widthOrtho - limitesCarro);
		}
		if((pos.x - limitesCarro) < -widthOrtho)
		{
			pos.x = (-widthOrtho + limitesCarro);
		}

		//nos cambia la posision
		transform.position = pos;
	}
}
