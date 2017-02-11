using UnityEngine;
using System.Collections;

public class addHandler : MonoBehaviour
{
	public static int plays;
	void Awake()
	{
		//JCGE 05/02/2017: para que no se destruya despues de que se cierre la escena 
		DontDestroyOnLoad(this.gameObject);	
	}
	public void plusPlay()
	{
		//JCGE 05/02/2017: Esta es la funcion que hace controla las jugadas para mostrar el add
		//                 Lo puse aqui porque la escena del juego se  resetea  cuando  pierdes
		//                 con esto solamente lo sumamos siendo una variable estatica
		plays++;
	}
}
