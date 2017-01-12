using UnityEngine;
using System.Collections;

public class scrollUV : MonoBehaviour {

	public float speed;
	Vector2 offset;
	float quadHeight;
	float quadWidth;
	public float multiplier;
	// JCGE Medimos el tamaño ortografico y lo acomodamos para el quad
	void Start () {
		quadHeight = Camera.main.orthographicSize * 2.0f;
		quadWidth = quadHeight * Screen.width / Screen.height;
		transform.localScale = new Vector3(quadWidth * multiplier, quadHeight * multiplier, 1f);
	}
	// JCGE Con esto movemos el quad
	// Si speed es positiva para abajo y si es negativo para hacia arriba
	void Update ()
	{
		offset = new Vector2 (0, Time.time * -speed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;		
	}
}
