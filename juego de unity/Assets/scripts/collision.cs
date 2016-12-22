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
	void OnTriggerEnter2D()
	{
		health--;
		if(health <= 0)
		{
			Die();
			ui.gameOverActivated();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}
