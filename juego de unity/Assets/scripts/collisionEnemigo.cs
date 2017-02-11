using UnityEngine;
using System.Collections;


public class collisionEnemigo : MonoBehaviour
{
	public Rigidbody2D rb;
	public float objctForceX;
	public float objctForceY;
	public bool objctdir;
	public int health = 1;
	void Start()
	{
		objctdir = true;
	}
	void Update()
	{	
		//JCGE: Esto hace que tenga un efecto de rebote alazar
		// Multiplicando por menos 1 para que cambie de direccion
		if (objctdir)
		{
			objctForceX = objctForceX * (-1);
			objctdir = false;
		}
		else
		{	
			objctForceX = objctForceX * (-1);
			objctdir = true;
		}
	}
	void OnTriggerEnter2D()
	{
		//Se mata a la verga
		health--;
		if(health <= 0)
		{
			Die();
		}
	}
	void OnCollisionEnter2D()
	{
		//JCGE: Le asignamos una direccion en X y Y
		rb.AddForce(new Vector2(objctForceX,objctForceY));
		//Debug.Log(objctdir);
	}
	public void Die()
	{
		Destroy(gameObject);
	}
}
