using UnityEngine;
using System.Collections;


public class collision : MonoBehaviour
{
	private uiManager ui;
	public int health = 1;

	void Start()
	{
		//mandas llamar el tag, y el archivo
		ui = GameObject.FindGameObjectWithTag("UiManager").GetComponent<uiManager>();
	}
	void OnTriggerEnter2D()
	{
		health--;
		if(health <= 0)
		{
			Die();
			if(gameObject.tag == "Enemy")
			{
				Debug.Log("Enemigo muerto");
			}
			else
			{
				Debug.Log("Player muerto");
				ui.gameOverActivated();
			}
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}
