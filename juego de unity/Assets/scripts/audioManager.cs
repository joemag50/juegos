﻿using UnityEngine;
using System.Collections;

public class audioManager : MonoBehaviour {
	//JCGE: lo creamos en el inicio del menu
	// Validamos que solo una cancion se este reproduciendo
	void Awake(){
		GameObject[] objs = GameObject.FindGameObjectsWithTag("music");
		if(objs.Length > 1)
			Destroy(this.gameObject);

		DontDestroyOnLoad(this.gameObject);
	} 
}