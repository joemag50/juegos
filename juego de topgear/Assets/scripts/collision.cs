﻿using UnityEngine;
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
	void OnTriggerEnter()
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
				//ui.gameOverActivated();
			}
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
}