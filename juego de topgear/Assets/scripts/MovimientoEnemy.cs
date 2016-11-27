using UnityEngine;
using System.Collections;

public class MovimientoEnemy : MonoBehaviour
{
	//variables
	public float maxSpeed = 0.5f;
	
	// Update is called once per frame
	void Update ()
	{
		//Esta variable es la que se utiliza para moverse
		Vector3 pos = transform.position;
		
		pos.y -= maxSpeed * Time.deltaTime;
		pos.z -= maxSpeed * Time.deltaTime;

		//nos cambia la posision
		transform.position = pos;
	}
}
