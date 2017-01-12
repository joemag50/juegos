using UnityEngine;
using System.Collections;

public class quadSize : MonoBehaviour {
	float quadHeight;
	float quadWidth;
	// JCGE Medimos el tamaño ortografico y lo acomodamos para el quad
	void Start () {
		quadHeight = Camera.main.orthographicSize * 2.0f;
		quadWidth = quadHeight * Screen.width / Screen.height;
		transform.localScale = new Vector3(quadWidth, quadHeight, 1f);
	}
}
