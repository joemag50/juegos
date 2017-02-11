using UnityEngine;
using System.Collections;


public class collision : MonoBehaviour
{
	private uiManagerGame ui;
	public int health = 1;
	void Start()
	{
		//mandas llamar el tag, y el archivo
		ui = GameObject.FindGameObjectWithTag("UiManager").GetComponent<uiManagerGame>();
	}
	//Funcion cuando entramos en contacto con algo
	void OnTriggerEnter2D()
	{
		health--;
		if(health <= 0)
		{
			Die();
			ui.gameOverActivated();
		}
	}
	//Funcion que destruye el objeto
	void Die()
	{
		Destroy(gameObject);
	}
}
